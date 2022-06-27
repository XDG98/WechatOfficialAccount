using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Parameter;
using WechatOfficialAccount.Services;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [ApiController]
    [Route("User")]
    public class UserController : MvcControllerBase
    {
        private IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        public async Task<IActionResult> Index()
        {
            List<GetUserInfoDto> getUserInfoDtoList = new List<GetUserInfoDto>();

            Result result = await GetUserList();
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserListDto getUserListDto = (GetUserListDto)result.Data;
                //await userService.BatchGetUserInfo(getUserListDto.data.openid);
                foreach (var item in getUserListDto.data.openid)
                {
                    result = await userService.GetUserInfo(item);
                    if (result.Code == HttpStatusCode.OK)
                    {
                        GetUserInfoDto getUserInfoDto = (GetUserInfoDto)result.Data;
                        getUserInfoDtoList.Add(getUserInfoDto);
                    }
                }
                ViewData["GetUserInfoDtoList"] = getUserInfoDtoList;
                return View();
            }
            else
            {
                return Content(JsonConvert.SerializeObject(result));
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/GetUserList")]
        public async Task<Result> GetUserList()
        {
            Result result = await userService.GetUserList();
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserListDto getUserListDto = (GetUserListDto)result.Data;
                return new Success(getUserListDto);
            }
            return result;
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/GetUserInfo")]
        public async Task<Result> GetUserInfo(string openid)
        {
            Result result = await userService.GetUserInfo(openid);
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserInfoDto getUserInfoDto = (GetUserInfoDto)result.Data;
                return new Success(getUserInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="openidList"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/User/BatchGetUserInfo")]
        public async Task<Result> BatchGetUserInfo(List<string> openidList)
        {
            Result result = await userService.BatchGetUserInfo(openidList);
            if (result.Code == HttpStatusCode.OK)
            {
                BatchGetUserInfoDto batchGetUserInfoDto = (BatchGetUserInfoDto)result.Data;
                return new Success(batchGetUserInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 设置用户备注名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/User/UpdateRemark")]
        public async Task<Result> UpdateRemark(UpdateRemarkParameter parameter)
        {
            parameter.openid = "oDDlM5ov88KTb-Jsqip-1AqdAeYU";
            parameter.remark = "123";
            return await userService.UpdateRemark(parameter);
        }

        /// <summary>
        /// 公众号已创建的标签页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/UserTagPage")]
        public async Task<IActionResult> UserTagPage()
        {
            return View();
        }
        /// <summary>
        /// 获取公众号已创建的标签列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/GetUserTagList")]
        public async Task<Result> GetUserTagList()
        {
            Result result = await userService.GetUserTagList();
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserTagListDto getUserTagListDto = (GetUserTagListDto)result.Data;
                return new Success(getUserTagListDto);
            }
            return result;
        }
        /// <summary>
        /// 获取公众号已创建的标签列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/GetUserTagDtoList")]
        public async Task<object> GetUserTagDtoList()
        {
            SearchParameter searchParameter = new SearchParameter();
            searchParameter.search = this.HttpContext.Request.Query["search"];
            searchParameter.sort = this.HttpContext.Request.Query["sort"];
            searchParameter.offset = int.Parse(this.HttpContext.Request.Query["offset"]);
            searchParameter.limit = int.Parse(this.HttpContext.Request.Query["limit"]);

            Result result = await userService.GetUserTagList();
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserTagListDto getUserTagListDto = (GetUserTagListDto)result.Data;

                if (!string.IsNullOrEmpty(searchParameter.search))
                {
                    getUserTagListDto.tags = getUserTagListDto.tags.Where(item => item.id.ToString().Contains(searchParameter.search) || item.name.Contains(searchParameter.search)).ToList();
                }
                //if (searchParameter.sort != "sequence")
                //{
                //    getUserTagListDto.tags = getUserTagListDto.tags.OrderByDescending(item => item.id).ToList();
                //}
                SearchDto searchDto = new SearchDto();
                searchDto.total = getUserTagListDto.tags.Count;
                searchDto.rows = getUserTagListDto.tags.Skip(searchParameter.offset).Take(searchParameter.limit).ToList();
                return searchDto;
            }
            throw new Exception("fail");
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/CreateTag")]
        public async Task<Result> CreateTag(CreateTagParameter parameter)
        {
            Result result = await userService.CreateTag(parameter);
            if (result.Code == HttpStatusCode.OK)
            {
                GetUserTagListDto getUserTagListDto = (GetUserTagListDto)result.Data;
                return new Success(getUserTagListDto);
            }
            return result;
        }
    }
}
