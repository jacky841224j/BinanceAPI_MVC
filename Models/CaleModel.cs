namespace BinanceAPI_MVC.Models
{
    public class CaleModel
    {
        /// <summary> 使用者輸入值 </summary>
        //public FrontFilterModel FrontFilterLIST { get; set; }

        /// <summary> 24小時交易量回傳值 </summary>
        public List<DayTradingVolume> DayTradingVolumesList { get; set; }

        /// <summary> K線回傳值 </summary>
        public List<KLineModel> KLineList { get; set; }

        /// <summary> 時間週期 </summary>
        public string TimeInterval { get; set; }

        /// <summary> 數學符號1 </summary>
        public CompareModel Compare { get; set; }

        ///// <summary> 數學符號2 </summary>
        //public CompareModel Compare2 { get; set; }

        /// <summary> 判斷式 </summary>
        //public LogicalModel Logical { get; set; }

        /// <summary> MA參數1 </summary>
        public int MAParam_A { get; set; }

        /// <summary> MA參數2 </summary>
        public int MAParam_B { get; set; }

        ///// <summary> MA參數3 </summary>
        //public int? MAParam_C { get; set; }

        ///// <summary> MA參數2 </summary>
        //public int? MAParam_D { get; set; }
    }
}
