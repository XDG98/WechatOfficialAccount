using SqlSugar;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Models.Parameter;

namespace WechatOfficialAccount.Services
{
    public class UserDBService
    {
        private readonly SqlSugarScope sqlSugarScope;
        public UserDBService()
        {
            sqlSugarScope = DBConnection.sqlSugarScope;
        }

        public async Task<int> Insert(WeiXin_User weiXin_User)
        {
            return await sqlSugarScope.Insertable(weiXin_User).ExecuteCommandAsync();
        }

        public async Task<WeiXin_User> First()
        {
            ISugarQueryable<WeiXin_User> queryable = sqlSugarScope.Queryable<WeiXin_User>();
            WeiXin_User weiXin_User = await queryable.FirstAsync();

            return weiXin_User;
        }

        public async Task<SearchDto> Query()
        {
            SearchDto searchDto = new SearchDto();

            ISugarQueryable<WeiXin_User> queryable = sqlSugarScope.Queryable<WeiXin_User>();
            searchDto.total = queryable.Count();
            searchDto.rows = await queryable.ToListAsync();

            return searchDto;
        }

        public async Task<SearchDto> QueryPage(SearchParameter parameter)
        {
            SearchDto searchDto = new SearchDto();

            ISugarQueryable<WeiXin_User> queryable = sqlSugarScope.Queryable<WeiXin_User>();
            if (!string.IsNullOrEmpty(parameter.search))
            {
                queryable.Where(item => item.openid.ToString().Contains(parameter.search) || item.city.Contains(parameter.search));
            }
            searchDto.total = queryable.Count();
            searchDto.rows = await queryable.ToPageListAsync(parameter.pageNumber, parameter.limit);

            return searchDto;
        }

        public async Task<int> Update(WeiXin_User weiXin_User)
        {
            return await sqlSugarScope.Updateable<WeiXin_User>(weiXin_User).ExecuteCommandAsync();
        }

        public async Task<int> BatchTagging(BatchTaggingParameter parameter)
        {
            return await sqlSugarScope.Updateable<WeiXin_User>()
                .ReSetValue(item => item.tagid_list += "," + parameter.tagid)
                .Where(item => parameter.openid_list.Contains(item.openid)).ExecuteCommandAsync();
        }

        public async Task<int> BatchUnTagging(BatchTaggingParameter parameter)
        {
            return await sqlSugarScope.Updateable<WeiXin_User>()
                .ReSetValue(item => item.tagid_list += "," + parameter.tagid)
                .Where(item => parameter.openid_list.Contains(item.openid)).ExecuteCommandAsync();
        }

        public async Task<int> Delete(int id)
        {
            return await sqlSugarScope.Deleteable<WeiXin_User>(id).ExecuteCommandAsync();
        }

    }
}
