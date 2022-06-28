using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;
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
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> UpdateRemark(UpdateRemarkParameter parameter);

        /// <summary>
        /// 获取公众号已创建的标签
        /// </summary>
        /// <returns></returns>
        Task<Result> GetUserTagList();
        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> CreateTag(CreateTagParameter parameter);
        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> UpdateTag(Tag parameter);
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> DeleteTag(Tag parameter);
    }
}
