using System.ComponentModel;

namespace BinanceAPI_MVC.Models
{
    public enum HttpCode
    {
        /// <summary>成功</summary>
        [Description("Success")]
        Success = 0,

        /// <summary>失敗</summary>
        [Description("Fail")]
        Fail = 101,

        /// <summary>伺服器找不到請求的資源</summary>
        [Description("NotFound")]
        NotFound = 404,
    }
}
