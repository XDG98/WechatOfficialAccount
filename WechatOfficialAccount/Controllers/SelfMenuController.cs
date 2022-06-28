using Microsoft.AspNetCore.Mvc;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 自定义菜单管理
    /// </summary>
    [ApiController]
    [Route("SelfMenu")]
    public class SelfMenuController : Controller
    {
        private readonly ISelfMenuService selfMenuService;
        public SelfMenuController()
        {
            selfMenuService = new SelfMenuService();
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/SelfMenu/CreateMenu")]
        public async Task<Result> CreateMenu()
        {
            Result result = await selfMenuService.CreateMenu();
            return new Result();
        }

        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/SelfMenu/GetCurrentSelfmenuInfo")]
        public async Task<Result> GetCurrentSelfmenuInfo()
        {
            Result result = await selfMenuService.GetCurrentSelfmenuInfo();

            return result;
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/SelfMenu/DeleteMenu")]
        public async Task<Result> DeleteMenu()
        {
            Result result = await selfMenuService.DeleteMenu();
            return new Result();
        }

        /// <summary>
        /// 获取自定义菜单配置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/SelfMenu/GetMenu")]
        public async Task<Result> GetMenu()
        {
            Result result = await selfMenuService.GetMenu();
            return new Result();
        }
    }
}
