using WechatOfficialAccount.Models;

namespace WechatOfficialAccount.Services.Interface
{
    /// <summary>
    /// 自定义菜单管理接口
    /// </summary>
    interface ISelfMenuService
    {
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <returns></returns>
        Task<Result> CreateMenu();
        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        /// <returns></returns>
        Task<Result> GetCurrentSelfmenuInfo();
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        Task<Result> DeleteMenu();
        /// <summary>
        /// 获取自定义菜单配置
        /// </summary>
        /// <returns></returns>
        Task<Result> GetMenu();
    }
}
