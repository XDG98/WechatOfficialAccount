using Microsoft.AspNetCore.Mvc;
using WechatOfficialAccount.Helper;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// Mvc基本控制器
    /// </summary>
    public class MvcControllerBase : Controller
    {
        public static string appid;
        public static string appsecret;
        public static string WeiXinApi;
        public static string access_token;
        public static DateTime expires_in;
        public MvcControllerBase()
        {
            appid = AppSettingsHelper.GetWeiXinConfig("appid");
            appsecret = AppSettingsHelper.GetWeiXinConfig("appsecret");
            WeiXinApi = AppSettingsHelper.GetWeiXinConfig("WeiXinApi");
            access_token = AppSettingsHelper.GetWeiXinConfig("access_token");
            DateTime.TryParse(AppSettingsHelper.GetWeiXinConfig("expires_in"), out DateTime expiresIn);
            expires_in = expiresIn;
        }
    }
}
