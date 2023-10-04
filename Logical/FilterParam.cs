using BinanceAPI_MVC.Models;
using Newtonsoft.Json;

namespace BinanceAPI_MVC.Logical
{
    public class FilterParam : IFilterParam
    {
        private readonly string BaseUrl = "https://fapi.binance.com/fapi/v1";
        private static readonly HttpClient client = new HttpClient();
        public ICallAPI callAPI;

        public FilterParam(ICallAPI callAPI)
        {
            this.callAPI = callAPI;
        }

        public async Task<HttpResultModel<List<RspModel>>> Get(FrontFilterModel reqObj)
        {
            HttpResultModel<List<RspModel>> rspObj = new HttpResultModel<List<RspModel>>();
            rspObj.Success = false;
            rspObj.Code = (int)HttpCode.Fail;
            rspObj.Message = HttpCode.Fail.ToString();

            //取得交易對及24小時交易量
            var DayTradingVolumeList = await callAPI.GetDayTradingVolume();

            List<FilterResultModel> result;
            List<FilterResultModel> resultA;
            List<FilterResultModel> resultB;

            #region 第一組

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

                result = LogicOperation(reqObj.Logical1, resultA, resultB);
            }
            #endregion

            #region 第二組
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

                    result = LogicOperation(reqObj.Logical2, resultA, resultB);
                }
            }
            #endregion

            #region 第三組
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

                    result = LogicOperation(reqObj.Logical3, resultA, resultB);
                }
            }
            #endregion

            #region 第四組
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

                    result = LogicOperation(reqObj.Logical4, resultA, resultB);
                }
            }
            #endregion

            var rspData = ConvertToUnit(result.OrderByDescending(x => x.Volume).ToList());

            rspObj.Success = true;
            rspObj.Code = (int)HttpCode.Success;
            rspObj.Message = HttpCode.Success.ToString();
            rspObj.Data = rspData;

            return rspObj;
        }

        /// <summary> 計算參數主程式 </summary>
        public async Task<List<FilterResultModel>> CaleParam(CaleModel ObjList, List<FilterResultModel>? filterResultModels)
        {
            #region 取得K線

            List<KLineModel> KlinesParamList = new List<KLineModel>();

            if (filterResultModels == null)
            {
                KlinesParamList = await callAPI.GetKLines(ObjList.DayTradingVolumesList, ObjList.TimeInterval);
            }
            else
            {
                KlinesParamList = await callAPI.GetKLines(filterResultModels.Select(x => new DayTradingVolume
                {
                    Symbol = x.Symbol,
                }).ToList(), ObjList.TimeInterval);
            }
            #endregion

            List<AveragePriceModel> AveragePriceList_A = new List<AveragePriceModel>();
            List<AveragePriceModel> AveragePriceList_B = new List<AveragePriceModel>();

            List<Task> taskList = new List<Task>
            {
                Task.Run(() =>
                {
                    AveragePriceList_A = CaleAveragePrice(KlinesParamList, ObjList.MAParam_A);
                }),
                Task.Run(() =>
                {
                    AveragePriceList_B = CaleAveragePrice(KlinesParamList, ObjList.MAParam_B);
                })
            };

            await Task.WhenAll(taskList);

            var resultA = CompareAveragePrice(AveragePriceList_A, AveragePriceList_B, ObjList.Compare);

            var result = resultA.Select(x => new FilterResultModel
            {
                Symbol = x.Symbol,
                Volume = x.Volume,
            }).ToList();

            return result;
        }

        /// <summary> 計算均價 </summary>
        public List<AveragePriceModel> CaleAveragePrice(List<KLineModel> KlinesParamList, int MAParam)
        {
            var AveragePrice = new List<AveragePriceModel>();

            var distinctSymbols = KlinesParamList
            .Select(k => k.Symbol)
            .Distinct();

            foreach (var value in distinctSymbols)
            {
                if (KlinesParamList.Where(x => x.Symbol == value).ToList().Count < MAParam) continue;

                AveragePrice.Add(new AveragePriceModel
                {
                    Symbol = value,
                    AveragePrice = Math.Round(KlinesParamList.Where(x => x.Symbol == value).Reverse().Take(MAParam).Sum(y => y.ClosePrice) / MAParam, 7),
                    Volume = KlinesParamList.Where(x => x.Symbol == value).Select(x => x.Volume).FirstOrDefault(),
                });
            }

            return AveragePrice;
        }

        /// <summary> 比對均價 </summary>
        public List<AveragePriceModel> CompareAveragePrice(List<AveragePriceModel> AList, List<AveragePriceModel> BList, CompareModel compare)
        {
            var obj = new List<AveragePriceModel>();

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
                default:
                    break;
            }

            return obj;
        }

        /// <summary> 邏輯運算 </summary>
        public List<FilterResultModel> LogicOperation(LogicalModel logical, List<FilterResultModel> resultA, List<FilterResultModel> resultB)
        {
            List<FilterResultModel> result = new List<FilterResultModel>();

            switch (logical)
            {
                case LogicalModel.And:
                    var compareList = resultA.Select(x => (x.Symbol, x.Volume)).Intersect(resultB.Select(x => (x.Symbol, x.Volume))).ToList();
                    result = compareList.Select(x => new FilterResultModel
                    {
                        Symbol = x.Symbol,
                        Volume = x.Volume,
                    }).ToList();
                    break;

                case LogicalModel.Or:
                    compareList = resultA.Select(x => (x.Symbol, x.Volume)).Union(resultB.Select(x => (x.Symbol, x.Volume))).ToList();
                    result = compareList.Select(x => new FilterResultModel
                    {
                        Symbol = x.Symbol,
                        Volume = x.Volume,
                    }).ToList();
                    break;
            }

            return result;
        }

        /// <summary> 增加數字單位 </summary>
        public List<RspModel> ConvertToUnit(List<FilterResultModel> filterResultModel)
        {
            List<RspModel> rspModel = new List<RspModel>();

            foreach (var x in filterResultModel)
            {
                string unit = "";
                // 根据数字的大小确定中文单位
                if (x.Volume >= 100000000)
                {
                    x.Volume /= 100000000;
                    unit = "億";
                }
                else if (x.Volume >= 10000)
                {
                    x.Volume /= 10000;
                    unit = "萬";
                }

                rspModel.Add(new RspModel
                {
                    Symbol = x.Symbol,
                    Volume = x.Volume.ToString() + unit,
                });
            }

            return rspModel;
        }
    }
}
