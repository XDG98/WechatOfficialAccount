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
                    StorageableResult<WeiXin_Tag> x = await sqlSugarScope.Storageable(weiXin_TagList).ToStorageAsync();
                    int insertNum = await x.AsInsertable.ExecuteCommandAsync();
                    int updateNum = await x.AsUpdateable.ExecuteCommandAsync();
                    resultList.Add(new Success($"同步用户标签结果：插入{insertNum}条数据，更新{updateNum}条数据！"));
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
                        weiXin_User.subscribe = item.subscribe;
                        weiXin_User.nickname = item.nickname;
                        weiXin_User.sex = item.sex;
                        weiXin_User.language = item.language;
                        weiXin_User.country = item.country;
                        weiXin_User.province = item.province;
                        weiXin_User.city = item.city;
                        weiXin_User.headimgurl = item.headimgurl;
                        weiXin_User.subscribe_time = item.subscribe_time;
                        weiXin_User.unionid = item.unionid;
                        weiXin_User.remark = item.remark;
                        weiXin_User.groupid = item.groupid;
                        weiXin_User.tagid_list = string.Join(",", item.tagid_list);
                        weiXin_User.subscribe_scene = item.subscribe_scene;
                        weiXin_User.qr_scene = item.qr_scene;
                        weiXin_User.qr_scene_str = item.qr_scene_str;
                        weiXin_UserList.Add(weiXin_User);
                    }
                    StorageableResult<WeiXin_User> x = await sqlSugarScope.Storageable(weiXin_UserList).ToStorageAsync();
                    int insertNum = await x.AsInsertable.ExecuteCommandAsync();
                    int updateNum = await x.AsUpdateable.ExecuteCommandAsync();
                    resultList.Add(new Success($"同步用户结果：插入{insertNum}条数据，更新{updateNum}条数据！"));
                }
                #endregion

                return new Success(resultList);
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
            }

            return result;
        }

    }
}
