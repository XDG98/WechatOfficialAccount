using Microsoft.AspNetCore.Mvc;
using WechatOfficialAccount.Helper;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 保存系统设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/System/Save")]
        public async Task<Result> Save([FromForm] SystemConfig parameter)
        {
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            dataDic.Add("AlertTime", parameter.AlertTime.ToString());
            Result result = await AppSettingsHelper.SaveSystemConfig(dataDic);
            return result;
        }

    }
}
