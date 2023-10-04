using BinanceAPI_MVC.Logical;
using BinanceAPI_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BinanceAPI_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IFilterParam _filterParam;

        public HomeController(ILogger<HomeController> logger, IFilterParam filterParam)
        {
            _logger = logger;
            _filterParam = filterParam;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(FrontFilterModel reqObj)
        {
            //計算程式執行時間
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var rspObj = await _filterParam.Get(reqObj);
            var temp = rspObj.Data;

            //停止計時
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                    ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);

            if (rspObj.Success)
            {
                ViewBag.List = temp;
                ViewBag.SpendTime = elapsedTime;
            }

            return View("Index");
        }
    }
}