namespace BinanceAPI_MVC.Models
{
    public class HttpResultModel<T>
    {
        /// <summary>
        /// 成功狀態。
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 代碼。
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 資料。
        /// </summary>
        public T Data { get; set; }
    }
}
