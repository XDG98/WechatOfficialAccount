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
            appid = AppSettingsHelper.GetAppSettings("appid");
            appsecret = AppSettingsHelper.GetAppSettings("appsecret");
            WeiXinApi = AppSettingsHelper.GetAppSettings("WeiXinApi");
            access_token = AppSettingsHelper.GetAppSettings("access_token");
            DateTime.TryParse(AppSettingsHelper.GetAppSettings("expires_in"), out DateTime expiresIn);
            expires_in = expiresIn;
        }
    }
}
