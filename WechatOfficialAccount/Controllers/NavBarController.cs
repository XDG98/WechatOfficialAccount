using Microsoft.AspNetCore.Mvc;
using System.Net;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 菜单栏管理
    /// </summary>
    [ApiController]
    [Route("NavBar")]
    public class NavBarController : Controller
    {
        private INavBarService navBarService;
        public NavBarController()
        {
            navBarService = new NavBarService();
        }

        /// <summary>
        /// 获取菜单栏列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/NavBar/GetNavBarList")]
        public async Task<Result> GetNavBarList()
        {
            Result result = await navBarService.GetNavBarList();
            if (result.Code == HttpStatusCode.OK)
            {
                Dictionary<string, List<GetNavBarListDto>> getNavBarListDto = (Dictionary<string, List<GetNavBarListDto>>)result.Data;
                return new Success(getNavBarListDto);
            }
            return result;
        }

    }
}
