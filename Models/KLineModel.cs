namespace BinanceAPI_MVC.Models
{
    /// <summary> K線回傳值 </summary>
    public class KLineModel
    {
        /// <summary> 交易對 </summary>
        public string Symbol { get; set; }

        ///// <summary> 開盤時間 </summary>
        //public long OpenTime { get; set; }

        ///// <summary> 開盤價 </summary>
        //public decimal OpenPrice { get; set; }

        ///// <summary> 最高價 </summary>
        //public decimal HighPrice { get; set; }

        ///// <summary> 最低價 </summary>
        //public decimal LowPrice { get; set; }

        /// <summary> 收盤價 </summary>
        public decimal ClosePrice { get; set; }

        /// <summary> 成交量 </summary>
        public decimal QuoteVolume { get; set; }

        ///// <summary> 收盤時間 </summary>
        //public decimal CloseTime { get; set; }

        ///// <summary> 成交額 </summary>
        //public decimal TradeAmount { get; set; }

        ///// <summary> 成交筆數 </summary>
        //public decimal TradeCount { get; set; }

        ///// <summary> 主動買入成交量 </summary>
        //public decimal BuyVolume { get; set; }

        ///// <summary> 主動買入成交額 </summary>
        //public decimal BuyAmount { get; set; }

        ///// <summary> 請忽略參數 </summary>
        //public decimal Ignore { get; set; }
    }
}
