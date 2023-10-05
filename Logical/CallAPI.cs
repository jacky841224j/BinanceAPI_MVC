using BinanceAPI_MVC.Models;
using Newtonsoft.Json;
using System;

namespace BinanceAPI_MVC.Logical
{
    public class CallAPI : ICallAPI
    {
        private readonly string BaseUrl = "https://fapi.binance.com/fapi/v1";
        private static readonly HttpClient client = new HttpClient();
        public DateTime UpdateTime = DateTime.UtcNow;
        public List<DayTradingVolume> dayTradingVolumes = new List<DayTradingVolume>();
        public List<KLineModel> kLineModels = new List<KLineModel>();

        /// <summary> 取得交易對及24小時交易量 </summary>
        public async Task<List<DayTradingVolume>> GetDayTradingVolume()
        {
            //判斷是否需更新資料
            TimeSpan timeDifference = DateTime.UtcNow - UpdateTime;

            if (dayTradingVolumes.Count == 0 || timeDifference >= TimeSpan.FromMinutes(1))
            {
                if (dayTradingVolumes.Count != 0)
                    dayTradingVolumes.Clear();

                // API 的 URL
                string apiUrl = BaseUrl + "/ticker/24hr";

                // 發送 GET 請求
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // 檢查回應的狀態碼
                if (response.IsSuccessStatusCode)
                {
                    // 讀取回應內容
                    string Result = await response.Content.ReadAsStringAsync();
                    dayTradingVolumes = JsonConvert.DeserializeObject<List<DayTradingVolume>>(Result).OrderByDescending(x => x.QuoteVolume).ToList();
                }

                UpdateTime = DateTime.UtcNow;
            }

            return dayTradingVolumes;
        }

        /// <summary> 取得K線 </summary>
        public async Task<List<KLineModel>> GetKLines(List<DayTradingVolume> ObjList, string TimeInterval)
        {
            List<KLineModel> KLineList = new List<KLineModel>();

            //判斷是否需更新資料
            TimeSpan timeDifference = DateTime.UtcNow - UpdateTime;

            if (kLineModels.Count == 0 || timeDifference >= TimeSpan.FromMinutes(1) )
            {
                var tasks = dayTradingVolumes.Select(async obj =>
                {
                    string url = BaseUrl + $@"/klines?symbol={obj.Symbol}&interval={TimeInterval}&limit=365";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string Result = await response.Content.ReadAsStringAsync();
                        List<List<object>> data = JsonConvert.DeserializeObject<List<List<object>>>(Result);

                        foreach (var item in data)
                        {
                            KLineModel klineData = new KLineModel
                            {
                                Symbol = obj.Symbol,
                                ClosePrice = Convert.ToDecimal(item[4]),
                                QuoteVolume = dayTradingVolumes.Where(x => x.Symbol == obj.Symbol).Select(x => x.QuoteVolume).FirstOrDefault(),
                            };

                            kLineModels.Add(klineData);
                        }
                    }
                }).ToList();

                // 等待所有非同步任務完成
                await Task.WhenAll(tasks);

                KLineList = kLineModels;
                UpdateTime = DateTime.UtcNow;

            }

            else if (ObjList == null)
            {
                KLineList = kLineModels;
            }

            else if (ObjList != null)
            {
                foreach(var obj in ObjList)
                {
                    KLineList.AddRange(kLineModels.Where(x => x.Symbol == obj.Symbol).ToList());
                }
            }

            return KLineList;
        }
    }
}
