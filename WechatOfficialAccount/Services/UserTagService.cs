using Newtonsoft.Json;
using SqlSugar;
using System.Net;
using WechatOfficialAccount.Controllers;
using WechatOfficialAccount.Helper;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Models.Parameter;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Services
{
    public class UserTagService : MvcControllerBase, IUserTagService
    {
        private readonly UserTagDBService userTagDBService;
        private readonly UserDBService userDBService;
        public UserTagService()
        {
            userTagDBService = new UserTagDBService();
            userDBService = new UserDBService();
        }

        /// <summary>
        /// 获取公众号已创建的标签列表
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetUserTagList()
        {
            string url = $"{WeiXinApi}/tags/get?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserTagListDto getUserTagListDto = JsonConvert.DeserializeObject<GetUserTagListDto>(result.Data.ToString());
                result = new Success(getUserTagListDto);
            }
            return result;
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <returns></returns>
        public async Task<Result> CreateTag(CreateTagParameter parameter)
        {
            string url = $"{WeiXinApi}/tags/create?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                Tag tag = JsonConvert.DeserializeObject<Tag>(result.Data.ToString());
                result = new Success(tag);
                //数据库同步新增标签
                await userTagDBService.Insert(new WeiXin_Tag() { id = tag.tag.id, name = tag.tag.name });
            }
            return result;
        }

        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<Result> UpdateTag(Tag parameter)
        {
            string url = $"{WeiXinApi}/tags/update?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
                //数据库同步修改标签
                await userTagDBService.Update(new WeiXin_Tag() { id = parameter.tag.id, name = parameter.tag.name });
            }
            return result;
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<Result> DeleteTag(Tag parameter)
        {
            string url = $"{WeiXinApi}/tags/delete?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
                //数据库同步删除标签
                await userTagDBService.Delete(parameter.tag.id);
            }
            return result;
        }

        /// <summary>
        /// 批量为用户打标签
        /// </summary>
        /// <returns></returns>
        public async Task<Result> BatchTagging(BatchTaggingParameter parameter)
        {
            string url = $"{WeiXinApi}/tags/members/batchtagging?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
                //数据库同步修改
                await userDBService.BatchTagging(parameter);
            }
            return result;
        }

        /// <summary>
        /// 批量为用户取消标签
        /// </summary>
        /// <returns></returns>
        public async Task<Result> BatchUnTagging(BatchTaggingParameter parameter)
        {
            string url = $"{WeiXinApi}/tags/members/batchuntagging?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
                //数据库同步修改
                await userDBService.BatchUnTagging(parameter);
            }
            return result;
        }

        /// <summary>
        /// 获取用户身上的标签列表
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetIdList()
        {
            string url = $"{WeiXinApi}/tags/getidlist?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, null);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
            }
            return result;
        }

    }
}
