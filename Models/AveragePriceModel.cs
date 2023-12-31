﻿namespace BinanceAPI_MVC.Models
{
    public class AveragePriceModel
    {
        /// <summary> 交易對 </summary>
        public string Symbol { get; set; }

        /// <summary> 均價 </summary>
        public decimal AveragePrice { get; set; }

        /// <summary> 成交量 </summary>
        public decimal Volume { get; set; }
    }
}
