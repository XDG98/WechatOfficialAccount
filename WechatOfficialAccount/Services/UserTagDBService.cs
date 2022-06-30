using SqlSugar;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.Entity;

namespace WechatOfficialAccount.Services
{
    public class UserTagDBService
    {
        private readonly SqlSugarScope sqlSugarScope;
        public UserTagDBService()
        {
            sqlSugarScope = DBConnection.sqlSugarScope;
        }

        public async Task<int> Insert(object obj)
        {
            return await sqlSugarScope.Insertable(obj).ExecuteCommandAsync();
        }

        public async Task<WeiXin_Tag> First()
        {
            ISugarQueryable<WeiXin_Tag> queryable = sqlSugarScope.Queryable<WeiXin_Tag>();
            WeiXin_Tag weiXin_Tag = await queryable.FirstAsync();

            return weiXin_Tag;
        }

        public async Task<List<WeiXin_Tag>> Query()
        {
            ISugarQueryable<WeiXin_Tag> queryable = sqlSugarScope.Queryable<WeiXin_Tag>();
            List<WeiXin_Tag> weiXin_TagList = await queryable.ToListAsync();

            return weiXin_TagList;
        }

        public async Task<SearchDto> QueryPage(SearchParameter parameter)
        {
            SearchDto searchDto = new SearchDto();

            ISugarQueryable<WeiXin_Tag> queryable = sqlSugarScope.Queryable<WeiXin_Tag>();
            if (!string.IsNullOrEmpty(parameter.search))
            {
                queryable.Where(item => item.id.ToString().Contains(parameter.search) || item.name.Contains(parameter.search));
            }
            searchDto.total = queryable.Count();
            List<WeiXin_Tag> weiXin_TagList = await queryable.ToPageListAsync(parameter.pageNumber, parameter.limit);
            searchDto.rows = weiXin_TagList;

            return searchDto;
        }

        public async Task<int> Update(WeiXin_Tag weiXin_Tag)
        {
            return await sqlSugarScope.Updateable<WeiXin_Tag>(weiXin_Tag).ExecuteCommandAsync();
        }

        public async Task<int> Delete(int id)
        {
            return await sqlSugarScope.Deleteable<WeiXin_Tag>(id).ExecuteCommandAsync();
        }
    }
}
