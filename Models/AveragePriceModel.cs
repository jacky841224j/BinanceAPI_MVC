namespace BinanceAPI_MVC.Models
{
    public class AveragePriceModel
    {
        public int ID { get; set; }

        /// <summary> 交易對 </summary>
        public string Symbol { get; set; }

        /// <summary> 均價 </summary>
        public decimal AveragePrice { get; set; }
    }
}
