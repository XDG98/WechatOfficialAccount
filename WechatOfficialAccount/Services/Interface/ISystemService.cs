using WechatOfficialAccount.Models;

namespace WechatOfficialAccount.Services.Interface
{
    interface ISystemService
    {
        /// <summary>
        /// 同步微信公众号数据
        /// </summary>
        Task<Result> SynchronousData();
    }
}
