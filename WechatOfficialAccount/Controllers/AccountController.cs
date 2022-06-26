using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WechatOfficialAccount.Helper;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Parameter;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 账户管理
    /// </summary>
    [ApiController]
    [Route("Account")]
    public class AccountController : MvcControllerBase
    {
        private IAccountService accountService;
        public AccountController()
        {
            accountService = new AccountService();
        }

        public IActionResult Index()
        {
            ViewData["appid"] = appid;
            ViewData["appsecret"] = appsecret;
            return View();
        }

        /// <summary>
        /// 设置账户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Account/SetAccountInfo")]
        public async Task<Result> SetAccountInfo([FromForm] SetAccountInfoParameter data)
        {
            Result result = await accountService.SetAccountInfo(data);
            return result;
        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Account/GetAccessToken")]
        public async Task<Result> GetAccessToken()
        {
            if (string.IsNullOrEmpty(appid) || string.IsNullOrEmpty(appsecret))
            {
                return new Fail("请先设置账户信息");
            }
            Result result = await accountService.GetAccessToken();
            return result;
        }

        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Account/GetApiDomainIp")]
        public async Task<Result> GetApiDomainIp()
        {
            Result result = await accountService.GetApiDomainIp();
            return result;
        }

        /// <summary>  
        /// 根据IP获取物理地址  
        /// </summary>  
        /// <param name="ip">Ip地址</param>  
        /// <returns></returns>  
        [HttpGet]
        [Route("/Account/GetIpAddress")]
        public async Task<Result> GetIpAddress(string ip)
        {
            Result result = await accountService.GetIpAddress(ip);
            return result;
        }

        /// <summary>
        /// 微信服务器地址信息列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Account/IpAddressPage")]
        public async Task<IActionResult> IpAddressPage()
        {
            Result result = await accountService.GetIpAddressList();
            if (result.Code == HttpStatusCode.OK)
            {
                ViewData["GetIpAddressDtoList"] = result.Data as List<GetIpAddressDto>;
                return View();
            }
            else
            {
                return Content(JsonConvert.SerializeObject(result));
            }
        }
        /// <summary>
        /// 获取微信服务器地址信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Account/GetIpAddressList")]
        public async Task<Result> GetIpAddressList()
        {
            Result result = await accountService.GetIpAddressList();
            return result;
        }
    }
}
