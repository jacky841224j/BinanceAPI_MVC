using BinanceAPI_MVC.Models;

namespace BinanceAPI_MVC.Logical
{
    public interface ICallAPI
    {
        /// <summary> 取得交易對及24小時交易量 </summary>
        Task<List<DayTradingVolume>> GetDayTradingVolume();

        /// <summary> 取得K線 </summary>
        Task<List<KLineModel>> GetKLines(List<DayTradingVolume>? ObjList, string TimeInterval);
    }
}
