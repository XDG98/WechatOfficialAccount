using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Models.Parameter;

namespace WechatOfficialAccount.Services.Interface
{
    /// <summary>
    /// 用户标签管理接口
    /// </summary>
    interface IUserTagService
    {
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

        /// <summary>
        /// 批量为用户打标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> BatchTagging(BatchTaggingParameter parameter);
        /// <summary>
        /// 批量为用户取消标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> BatchUnTagging(BatchTaggingParameter parameter);
        /// <summary>
        /// 获取用户身上的标签列表
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<Result> GetIdList();
    }
}
