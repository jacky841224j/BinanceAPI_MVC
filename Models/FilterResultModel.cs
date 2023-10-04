namespace BinanceAPI_MVC.Models
{
    public class FilterResultModel
    {
        /// <summary> 交易對 </summary>
        public string Symbol { get; set; }

        /// <summary> 成交量 </summary>
        public decimal Volume { get; set; }
    }
}
