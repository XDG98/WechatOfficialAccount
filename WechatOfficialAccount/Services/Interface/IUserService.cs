using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Parameter;

namespace WechatOfficialAccount.Services.Interface
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    interface IUserService
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task<Result> GetUserList();
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Task<Result> GetUserInfo(string openid);
        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="openidList"></param>
        /// <returns></returns>
        Task<Result> BatchGetUserInfo(List<string> openidList);
        /// <summary>
        /// 设置用户备注名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Result> UpdateRemark(UpdateRemarkParameter data);
    }
}
