using Newtonsoft.Json;
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
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class UserService : MvcControllerBase, IUserService
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetUserList()
        {
            string url = $"{WeiXinApi}/user/get?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserListDto getUserListDto = JsonConvert.DeserializeObject<GetUserListDto>(result.Data.ToString());
                result = new Success(getUserListDto);
            }
            return result;
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async Task<Result> GetUserInfo(string openid)
        {
            string url = $"{WeiXinApi}/user/info?access_token={access_token}&openid={openid}&lang=zh_CN";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserInfoDto getUserInfoDto = JsonConvert.DeserializeObject<GetUserInfoDto>(result.Data.ToString());
                result = new Success(getUserInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public async Task<Result> BatchGetUserInfo(List<string> openidList)
        {
            string url = $"{WeiXinApi}/user/info/batchget?access_token={access_token}";
            BatchGetUserInfoParameter batchGetUserInfoParameter = new BatchGetUserInfoParameter();
            foreach (var item in openidList)
            {
                batchGetUserInfoParameter.user_list.Add(new UserListData() { openid = item, lang = "zh_CN" });
            }
            Result result = await HttpClienttHelper.WeiXinPost(url, batchGetUserInfoParameter);
            if (result.Code == HttpStatusCode.OK)
            {
                BatchGetUserInfoDto batchGetUserInfoDto = JsonConvert.DeserializeObject<BatchGetUserInfoDto>(result.Data.ToString());
                result = new Success(batchGetUserInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 设置用户备注名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Result> UpdateRemark(UpdateRemarkParameter parameter)
        {
            string url = $"{WeiXinApi}/user/info/updateremark?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinPost(url, parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                result = new Success(result.Data);
            }
            return result;
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
                GetUserTagListDto getUserTagListDto = JsonConvert.DeserializeObject<GetUserTagListDto>(result.Data.ToString());
                result = new Success(getUserTagListDto);
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
            }
            return result;
        }
    }
}
