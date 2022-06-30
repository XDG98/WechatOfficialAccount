using SqlSugar;
using System.Net;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Services
{
    public class SystemService : ISystemService
    {
        private readonly SqlSugarScope sqlSugarScope;
        private readonly IUserService userService;
        private readonly IUserTagService userTagService;
        public SystemService()
        {
            sqlSugarScope = DBConnection.sqlSugarScope;
            userService = new UserService();
            userTagService = new UserTagService();
        }

        public async Task<Result> SynchronousData()
        {
            Result result = new Result();
            try
            {
                List<Result> resultList = new List<Result>();

                #region 同步标签
                result = await userTagService.GetUserTagList();
                if (result.Code == HttpStatusCode.OK)
                {
                    GetUserTagListDto getUserTagListDto = (GetUserTagListDto)result.Data;
                    List<WeiXin_Tag> weiXin_TagList = new List<WeiXin_Tag>();
                    foreach (var item in getUserTagListDto.tags)
                    {
                        WeiXin_Tag weiXin_Tag = new WeiXin_Tag();
                        weiXin_Tag.id = item.id;
                        weiXin_Tag.name = item.name;
                        weiXin_Tag.count = item.count;
                        weiXin_TagList.Add(weiXin_Tag);
                    }
                    int num = await sqlSugarScope.Insertable(weiXin_TagList).ExecuteCommandAsync();
                    resultList.Add(new Success($"用户标签同步{num}条数据！"));
                }
                #endregion

                #region 同步用户
                result = await userService.GetAllUserInfoDtoList();
                if (result.Code == HttpStatusCode.OK)
                {
                    List<WeiXin_User> weiXin_UserList = new List<WeiXin_User>();
                    List<GetUserInfoDto> getUserInfoDtoList = (List<GetUserInfoDto>)result.Data;
                    foreach (var item in getUserInfoDtoList)
                    {
                        WeiXin_User weiXin_User = new WeiXin_User();
                        weiXin_User.openid = item.openid;
                        weiXin_User.sex = item.sex;
                        weiXin_User.language = item.language;
                        weiXin_User.country = item.country;
                        weiXin_User.province = item.province;
                        weiXin_User.city = item.city;
                        weiXin_User.subscribe_time = item.subscribe_time;
                        weiXin_User.groupid = item.groupid;
                        weiXin_User.tagid_list = string.Join(",", item.tagid_list);
                        weiXin_UserList.Add(weiXin_User);
                    }
                    int num = await sqlSugarScope.Insertable(weiXin_UserList).ExecuteCommandAsync();
                    resultList.Add(new Success($"用户同步{num}条数据！"));
                }
                #endregion

                return new Success(result);
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
            }

            return result;
        }

    }
}
