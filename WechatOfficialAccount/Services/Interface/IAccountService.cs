using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Parameter;

namespace WechatOfficialAccount.Services.Interface
{
    /// <summary>
    /// 账户管理接口
    /// </summary>
    interface IAccountService
    {
        /// <summary>
        /// 设置账户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Result> SetAccountInfo(SetAccountInfoParameter data);
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <returns></returns>
        Task<Result> GetAccessToken();
        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <returns></returns>
        Task<Result> GetApiDomainIp();
        /// <summary>
        /// 根据IP获取物理地址
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        Task<Result> GetIpAddress(string ip);
        /// <summary>
        /// 获取微信服务器地址信息列表
        /// </summary>
        /// <returns></returns>
        Task<Result> GetIpAddressList();
    }
}
