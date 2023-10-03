using BinanceAPI_MVC.Models;

namespace BinanceAPI_MVC.Logical
{
    public interface IFilterParam
    {
        Task<HttpResultModel<List<FilterResultModel>>> Get(FrontFilterModel reqObj);

        /// <summary> 取得交易對及24小時交易量 </summary>
        Task<List<DayTradingVolume>> GetDayTradingVolume();

        /// <summary> 取得K線 </summary>
        Task<List<KLineModel>> GetKLines(List<DayTradingVolume> ObjList, string TimeInterval);

        /// <summary> 計算均價 </summary>
        List<AveragePriceModel> CaleAveragePrice(List<KLineModel> KlinesParamList, int MAParam);

        /// <summary> 比對參數 </summary>
        List<AveragePriceModel> CompareAveragePrice(List<AveragePriceModel> AList, List<AveragePriceModel> BList, CompareModel compare);
    }
}
