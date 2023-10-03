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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Search(FrontFilterModel reqObj)
        {
            var rspObj = await _filterParam.Get(reqObj);


        }
    }
}