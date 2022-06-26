using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;

namespace WechatOfficialAccount.Services.Interface
{
    /// <summary>
    /// 菜单栏管理接口
    /// </summary>
    interface INavBarService
    {
        /// <summary>
        /// 获取菜单栏列表
        /// </summary>
        /// <returns></returns>
        Task<Result> GetNavBarList();
    }
}
