using BinanceAPI_MVC.Models;

namespace BinanceAPI_MVC.Logical
{
    public interface IFilterParam
    {
        Task<HttpResultModel<List<RspModel>>> Get(FrontFilterModel reqObj);

        /// <summary> 計算均價 </summary>
        List<AveragePriceModel> CaleAveragePrice(List<KLineModel> KlinesParamList, int MAParam);

        /// <summary> 比對參數 </summary>
        List<AveragePriceModel> CompareAveragePrice(List<AveragePriceModel> AList, List<AveragePriceModel> BList, CompareModel compare);

        /// <summary> 邏輯運算 </summary>
        List<FilterResultModel> LogicOperation(LogicalModel logical, List<FilterResultModel> resultA, List<FilterResultModel> resultB);

        /// <summary> 增加數字單位 </summary>
        List<RspModel> ConvertToUnit(List<FilterResultModel> filterResultModel);
    }
}
