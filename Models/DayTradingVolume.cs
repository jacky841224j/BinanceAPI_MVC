namespace BinanceAPI_MVC.Models
{
    /// <summary> 24小時交易量回傳值 </summary>
    public class DayTradingVolume
    {
        /// <summary> 交易對 </summary>
        public string Symbol { get; set; }

        /// <summary> 交易量 </summary>
        public decimal QuoteVolume { get; set; }

    }
}
