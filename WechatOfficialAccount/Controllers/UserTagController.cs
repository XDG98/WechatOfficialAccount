using Microsoft.AspNetCore.Mvc;
using System.Net;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Entity;
using WechatOfficialAccount.Models.Parameter;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Entity.Tag;
using static WechatOfficialAccount.Models.Parameter.CreateTagParameter;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 用户标签管理
    /// </summary>
    [ApiController]
    [Route("UserTag")]
    public class UserTagController : MvcControllerBase
    {
        private static UserTagDBService tagDBService;
        private static IUserTagService userTagService;
        public UserTagController()
        {
            tagDBService = new UserTagDBService();
            userTagService = new UserTagService();
        }

        /// <summary>
        /// 公众号已创建的标签列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/UserTag/UserTagPage")]
        public async Task<IActionResult> UserTagPage()
        {
            return View();
        }

        /// <summary>
        /// 新增、编辑标签页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/UserTag/UserTagForm/{id?}")]
        public async Task<IActionResult> UserTagForm(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Tag tag = new Tag();
                SearchDto searchDto = await GetUserTagDtoList(new SearchParameter() { search = id }) as SearchDto;
                List<TagDetail> tagDetailList = searchDto.rows as List<TagDetail>;
                tag.tag = tagDetailList[0];
                ViewData["Tag"] = tag.tag;
            }

            return View();
        }

        /// <summary>
        /// 获取公众号已创建的标签列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/UserTag/GetUserTagList")]
        public async Task<Result> GetUserTagList()
        {
            return new Success(await tagDBService.Query());
        }

        /// <summary>
        /// 获取公众号已创建的标签列表(bootstarp-table)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/UserTag/GetUserTagDtoList")]
        public async Task<SearchDto> GetUserTagDtoList([FromQuery] SearchParameter parameter)
        {
            SearchDto searchDto = await tagDBService.QueryPage(parameter);
            return searchDto;
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/CreateTag")]
        public async Task<Result> CreateTag([FromBody] TagParameter parameter)
        {
            Result result = await userTagService.CreateTag(new CreateTagParameter() { tag = parameter });
            if (result.Code == HttpStatusCode.OK)
            {
                Tag tag = (Tag)result.Data;
                return new Success(tag);
            }
            return result;
        }

        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/UpdateTag")]
        public async Task<Result> UpdateTag([FromBody] TagDetail parameter)
        {
            Result result = await userTagService.UpdateTag(new Tag() { tag = parameter });
            return result;
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/DeleteTag")]
        public async Task<Result> DeleteTag([FromBody] TagDetail parameter)
        {
            Result result = await userTagService.DeleteTag(new Tag() { tag = parameter });
            return result;
        }


        /// <summary>
        /// 批量为用户打标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/BatchTagging")]
        public async Task<Result> BatchTagging([FromBody] BatchTaggingParameter parameter)
        {
            Result result = await userTagService.BatchTagging(parameter);
            return result;
        }

        /// <summary>
        /// 批量为用户取消标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/BatchUnTagging")]
        public async Task<Result> BatchUnTagging([FromBody] BatchTaggingParameter parameter)
        {
            Result result = await userTagService.BatchUnTagging(parameter);
            return result;
        }

        /// <summary>
        /// 获取用户身上的标签列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/UserTag/GetIdList")]
        public async Task<Result> GetIdList()
        {
            Result result = await userTagService.GetIdList();
            return result;
        }

    }
}
