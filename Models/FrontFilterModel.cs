namespace BinanceAPI_MVC.Models
{
    /// <summary> 前端頁面參數 </summary>
    public class FrontFilterModel
    {
        #region 第一組

        /// <summary> 時間週期 </summary>
        public string TimeInterval1 { get; set; }

        /// <summary> MA參數1-1 </summary>
        public int MAParam11 { get; set; }

        /// <summary> 相等1-1 </summary>
        public CompareModel Compare11 { get; set; }

        /// <summary> MA參數1-2 </summary>
        public int MAParam12 { get; set; }

        /// <summary> 比較1 </summary>
        public LogicalModel Logical1 { get; set; }

        /// <summary> MA參數1-3 </summary>
        public int? MAParam13 { get; set; }

        /// <summary> 相等1-2 </summary>
        public CompareModel Compare12 { get; set; }

        /// <summary> MA參數1-4 </summary>
        public int? MAParam14 { get; set; }

        #endregion

        #region 第二組

        /// <summary> 時間週期 </summary>
        public string TimeInterval2 { get; set; }

        /// <summary> MA參數2-1 </summary>
        public int? MAParam21 { get; set; }

        /// <summary> 相等2-1 </summary>
        public CompareModel Compare21 { get; set; }

        /// <summary> MA參數2-2 </summary>
        public int? MAParam22 { get; set; }

        /// <summary> 比較2 </summary>
        public LogicalModel Logical2 { get; set; }

        /// <summary> MA參數2-3 </summary>
        public int? MAParam23 { get; set; }

        /// <summary> 相等2-2 </summary>
        public CompareModel Compare22 { get; set; }

        /// <summary> MA參數2-4 </summary>
        public int? MAParam24 { get; set; }

        #endregion

        #region 第三組

        /// <summary> 時間週期 </summary>
        public string TimeInterval3 { get; set; }

        /// <summary> MA參數3-1 </summary>
        public int? MAParam31 { get; set; }

        /// <summary> 相等3-1 </summary>
        public CompareModel Compare31 { get; set; }

        /// <summary> MA參數3-2 </summary>
        public int? MAParam32 { get; set; }

        /// <summary> 比較3 </summary>
        public LogicalModel Logical3 { get; set; }

        /// <summary>? MA參數3-3 </summary>
        public int? MAParam33 { get; set; }

        /// <summary> 相等3-2 </summary>
        public CompareModel Compare32 { get; set; }

        /// <summary> MA參數3-4 </summary>
        public int? MAParam34 { get; set; }

        #endregion

        #region 第四組

        /// <summary> 時間週期 </summary>
        public string TimeInterval4 { get; set; }

        /// <summary> MA參數4-1 </summary>
        public int? MAParam41 { get; set; }

        /// <summary> 相等4-1 </summary>
        public CompareModel Compare41 { get; set; }

        /// <summary> MA參數4-2 </summary>
        public int? MAParam42 { get; set; }

        /// <summary> 比較4 </summary>
        public LogicalModel Logical4 { get; set; }

        /// <summary> MA參數4-3 </summary>
        public int? MAParam43 { get; set; }

        /// <summary> 相等4-2 </summary>
        public CompareModel Compare42 { get; set; }

        /// <summary> MA參數2-4 </summary>
        public int? MAParam44 { get; set; }

        #endregion
    }
}
