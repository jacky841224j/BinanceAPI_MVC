using BinanceAPI_MVC.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI_MVC.Logical
{
    public class FilterParam : IFilterParam
    {
        private readonly string BaseUrl = "https://fapi.binance.com/fapi/v1";
        public FilterParam()
        {

        }

        public async Task<HttpResultModel<List<FilterResultModel>>> Get(FrontFilterModel reqObj)
        {
            HttpResultModel<List<FilterResultModel>> rspObj = new HttpResultModel<List<FilterResultModel>>();
            rspObj.Success = false;
            rspObj.Code = (int)HttpCode.Fail;
            rspObj.Message = HttpCode.Fail.ToString();

            //取得交易對及24小時交易量
            var DayTradingVolumeList = await GetDayTradingVolume();

            List<FilterResultModel> resultA;
            List<FilterResultModel> resultB;
            List<FilterResultModel> result;

            resultA = await CaleParam(new CaleModel
            {
                DayTradingVolumesList = DayTradingVolumeList,
                TimeInterval = reqObj.TimeInterval1,
                Compare = reqObj.Compare11,
                MAParam_A = (int)reqObj.MAParam11,
                MAParam_B = (int)reqObj.MAParam12,
            }, null);

            result = resultA;

            if (reqObj.MAParam13 != null && reqObj.MAParam14 != null)
            {
                resultB = await CaleParam(new CaleModel
                {
                    DayTradingVolumesList = DayTradingVolumeList,
                    TimeInterval = reqObj.TimeInterval1,
                    Compare = reqObj.Compare12,
                    MAParam_A = (int)reqObj.MAParam13,
                    MAParam_B = (int)reqObj.MAParam14,
                }, null);

                switch (reqObj.Logical1)
                {
                    case LogicalModel.And:
                        var compareList = resultA.Select(x => x.Symbol).Intersect(resultB.Select(x => x.Symbol)).ToList();
                        result = compareList.Select(Symbol => new FilterResultModel
                        {
                            Symbol = Symbol,
                        }).ToList();
                        break;

                    case LogicalModel.Or:
                        compareList = resultA.Select(x => x.Symbol).Union(resultB.Select(x => x.Symbol)).ToList();
                        result = compareList.Select(Symbol => new FilterResultModel
                        {
                            Symbol = Symbol,
                        }).ToList();
                        break;
                }
            }

            if (reqObj.MAParam21 != null && reqObj.MAParam22 != null)
            {
                resultA = await CaleParam(new CaleModel
                {
                    DayTradingVolumesList = DayTradingVolumeList,
                    TimeInterval = reqObj.TimeInterval2,
                    Compare = reqObj.Compare21,
                    MAParam_A = (int)reqObj.MAParam21,
                    MAParam_B = (int)reqObj.MAParam22,
                }, result);

                result = resultA;

                if (reqObj.MAParam23 != null && reqObj.MAParam24 != null)
                {
                    resultB = await CaleParam(new CaleModel
                    {
                        DayTradingVolumesList = DayTradingVolumeList,
                        TimeInterval = reqObj.TimeInterval2,
                        Compare = reqObj.Compare22,
                        MAParam_A = (int)reqObj.MAParam23,
                        MAParam_B = (int)reqObj.MAParam24,
                    }, null);

                    switch (reqObj.Logical2)
                    {
                        case LogicalModel.And:
                            var compareList = resultA.Select(x => x.Symbol).Intersect(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;

                        case LogicalModel.Or:
                            compareList = resultA.Select(x => x.Symbol).Union(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;
                    }
                }
            }

            if (reqObj.MAParam31 != null && reqObj.MAParam32 != null)
            {
                resultA = await CaleParam(new CaleModel
                {
                    DayTradingVolumesList = DayTradingVolumeList,
                    TimeInterval = reqObj.TimeInterval3,
                    Compare = reqObj.Compare31,
                    MAParam_A = (int)reqObj.MAParam31,
                    MAParam_B = (int)reqObj.MAParam32,
                }, result);

                result = resultA;

                if (reqObj.MAParam33 != null && reqObj.MAParam34 != null)
                {
                    resultB = await CaleParam(new CaleModel
                    {
                        DayTradingVolumesList = DayTradingVolumeList,
                        TimeInterval = reqObj.TimeInterval3,
                        Compare = reqObj.Compare32,
                        MAParam_A = (int)reqObj.MAParam33,
                        MAParam_B = (int)reqObj.MAParam34,
                    }, null);

                    switch (reqObj.Logical3)
                    {
                        case LogicalModel.And:
                            var compareList = resultA.Select(x => x.Symbol).Intersect(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;

                        case LogicalModel.Or:
                            compareList = resultA.Select(x => x.Symbol).Union(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;
                    }
                }
            }

            if (reqObj.MAParam41 != null && reqObj.MAParam42 != null)
            {
                resultA = await CaleParam(new CaleModel
                {
                    DayTradingVolumesList = DayTradingVolumeList,
                    TimeInterval = reqObj.TimeInterval4,
                    Compare = reqObj.Compare41,
                    MAParam_A = (int)reqObj.MAParam41,
                    MAParam_B = (int)reqObj.MAParam42,
                }, result);

                result = resultA;

                if (reqObj.MAParam43 != null && reqObj.MAParam44 != null)
                {
                    resultB = await CaleParam(new CaleModel
                    {
                        DayTradingVolumesList = DayTradingVolumeList,
                        TimeInterval = reqObj.TimeInterval4,
                        Compare = reqObj.Compare42,
                        MAParam_A = (int)reqObj.MAParam43,
                        MAParam_B = (int)reqObj.MAParam44,
                    }, null);

                    switch (reqObj.Logical4)
                    {
                        case LogicalModel.And:
                            var compareList = resultA.Select(x => x.Symbol).Intersect(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;

                        case LogicalModel.Or:
                            compareList = resultA.Select(x => x.Symbol).Union(resultB.Select(x => x.Symbol)).ToList();
                            result = compareList.Select(Symbol => new FilterResultModel
                            {
                                Symbol = Symbol,
                            }).ToList();
                            break;
                    }
                }
            }


            rspObj.Success = true;
            rspObj.Code = (int)HttpCode.Success;
            rspObj.Message = HttpCode.Success.ToString();
            rspObj.Data = result;

            return rspObj;
        }

        /// <summary> 取得交易對及24小時交易量 </summary>
        public async Task<List<DayTradingVolume>> GetDayTradingVolume()
        {
            List<DayTradingVolume> repObj = new List<DayTradingVolume>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // API 的 URL
                    string apiUrl = BaseUrl + "/ticker/24hr";

                    // 發送 GET 請求
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // 檢查回應的狀態碼
                    if (response.IsSuccessStatusCode)
                    {
                        // 讀取回應內容
                        string Result = await response.Content.ReadAsStringAsync();
                        repObj = JsonConvert.DeserializeObject<List<DayTradingVolume>>(Result).OrderByDescending(x => x.QuoteVolume).ToList();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return repObj;
        }

        /// <summary> 取得K線 </summary>
        public async Task<List<KLineModel>> GetKLines(List<DayTradingVolume> ObjList, string TimeInterval)
        {
            List<KLineModel> repObj = new List<KLineModel>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    foreach (var obj in ObjList)
                    {
                        string url = BaseUrl + $@"/klines?symbol={obj.Symbol}&interval={TimeInterval}&limit=365";

                        // 發送 Get 請求
                        HttpResponseMessage response = await client.GetAsync(url);

                        // 檢查回應的狀態碼
                        if (response.IsSuccessStatusCode)
                        {
                            // 讀取回應內容
                            string Result = await response.Content.ReadAsStringAsync();

                            List<List<object>> data = JsonConvert.DeserializeObject<List<List<object>>>(Result);

                            foreach (var item in data)
                            {
                                KLineModel klineData = new KLineModel
                                {
                                    Symbol = obj.Symbol,
                                    //OpenTime = Convert.ToInt64(item[0]),
                                    //OpenPrice = Convert.ToDecimal(item[1]),
                                    //HighPrice = Convert.ToDecimal(item[2]),
                                    //LowPrice = Convert.ToDecimal(item[3]),
                                    ClosePrice = Convert.ToDecimal(item[4]),
                                    //Volume = Convert.ToDecimal(item[5]),
                                    //CloseTime = Convert.ToInt64(item[6]),
                                    //TradeAmount = Convert.ToDecimal(item[7]),
                                    //TradeCount = Convert.ToInt32(item[8]),
                                    //BuyVolume = Convert.ToDecimal(item[9]),
                                    //BuyAmount = Convert.ToDecimal(item[10]),
                                    //Ignore = Convert.ToDecimal(item[11])
                                };

                                repObj.Add(klineData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return repObj;
        }

        /// <summary> 計算均價 </summary>
        public List<AveragePriceModel> CaleAveragePrice(List<KLineModel> KlinesParamList, int MAParam)
        {
            var AveragePrice = new List<AveragePriceModel>();
            int id = 1;

            var distinctSymbols = KlinesParamList
            .Select(k => k.Symbol)
            .Distinct();

            foreach (var symbols in distinctSymbols)
            {
                if (KlinesParamList.Where(x => x.Symbol == symbols).ToList().Count < MAParam) continue;

                AveragePrice.Add(new AveragePriceModel
                {
                    ID = id++,
                    Symbol = symbols,
                    AveragePrice = Math.Round(KlinesParamList.Where(x => x.Symbol == symbols).Reverse().Take(MAParam).Sum(y => y.ClosePrice) / MAParam, 7),
                });
            }

            return AveragePrice;
        }

        /// <summary> 比對均價 </summary>
        public List<AveragePriceModel> CompareAveragePrice(List<AveragePriceModel> AList, List<AveragePriceModel> BList, CompareModel compare)
        {
            var obj = new List<AveragePriceModel>();

            try
            {
                switch (compare)
                {
                    case CompareModel.NotEquals:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice != b.AveragePrice)).ToList();
                        break;

                    case CompareModel.Equals:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice == b.AveragePrice)).ToList();
                        break;

                    case CompareModel.Greater:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice > b.AveragePrice)).ToList();
                        break;

                    case CompareModel.NoLessThan:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice >= b.AveragePrice)).ToList();
                        break;

                    case CompareModel.Less:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice < b.AveragePrice)).ToList();
                        break;

                    case CompareModel.NoMoreThan:
                        obj = AList.Where(a => BList.Any(b => b.Symbol == a.Symbol && a.AveragePrice <= b.AveragePrice)).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return obj;
        }

        /// <summary> 計算參數主程式 </summary>
        public async Task<List<FilterResultModel>> CaleParam(CaleModel ObjList, List<FilterResultModel>? filterResultModels)
        {
            #region 取得K線

            List<KLineModel> KlinesParamList = new List<KLineModel>();

            if (filterResultModels == null)
            {
                KlinesParamList = await GetKLines(ObjList.DayTradingVolumesList, ObjList.TimeInterval);
            }
            else
            {
                KlinesParamList = await GetKLines(filterResultModels.Select(x => new DayTradingVolume
                {
                    Symbol = x.Symbol,
                }).ToList(), ObjList.TimeInterval);
            }
            #endregion

            List<AveragePriceModel> AveragePriceList_A = new List<AveragePriceModel>();
            List<AveragePriceModel> AveragePriceList_B = new List<AveragePriceModel>();

            Task task1 = new Task(() =>
            {
                AveragePriceList_A = CaleAveragePrice(KlinesParamList, ObjList.MAParam_A);
            });

            Task task2 = new Task(() =>
            {
                AveragePriceList_B = CaleAveragePrice(KlinesParamList, ObjList.MAParam_B);
            });

            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);

            var resultA = CompareAveragePrice(AveragePriceList_A, AveragePriceList_B, ObjList.Compare);

            var result = resultA.Select(x => new FilterResultModel
            {
                ID = x.ID,
                Symbol = x.Symbol,
            }).ToList();

            return result;
        }
    }
}
