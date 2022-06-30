using Microsoft.AspNetCore.Mvc;
using WechatOfficialAccount.Helper;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    [ApiController]
    [Route("System")]
    public class SystemController : Controller
    {
        private readonly ISystemService systemService;
        public SystemController()
        {
            systemService = new SystemService();
        }

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

        /// <summary>
        /// 同步微信公众号数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/System/SynchronousData")]
        public async Task<Result> SynchronousData()
        {
            if (!DBConnection.GetConnectionStatus())
            {
                return new Fail("数据库连接失败，请检查配置连接字符串是否正确！");
            }
            return await systemService.SynchronousData();
        }

        /// <summary>
        /// 获取枚举项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/System/GetEnumDescriptionList")]
        public async Task<Result> GetEnumDescriptionList(string enumName)
        {
            List<EnumDto> enumDtoList = EnumHelper.GetEnumDescriptionList(enumName);
            return new Success(enumDtoList);
        }

    }
}
