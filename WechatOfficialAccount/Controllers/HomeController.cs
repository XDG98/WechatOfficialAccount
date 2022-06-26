using Microsoft.AspNetCore.Mvc;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public new IActionResult NotFound()
        {
            return View();
        }

    }
}