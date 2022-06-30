using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    /// 用户管理
    /// </summary>
    [ApiController]
    [Route("User")]
    public class UserController : MvcControllerBase
    {
        private IUserService userService;
        private static UserDBService userDBService;
        public UserController()
        {
            userService = new UserService();
            userDBService = new UserDBService();
        }

        public async Task<IActionResult> Index()
        {
            ViewData["GetUserInfoDtoList"] = GetAllUserInfoDtoList();
            return View();
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetUserInfoDto>> GetAllUserInfoDtoList()
        {
            Result result = await userService.GetAllUserInfoDtoList();
            if (result.Code == HttpStatusCode.OK)
            {
                return (List<GetUserInfoDto>)result.Data;
            }
            return new List<GetUserInfoDto>();
        }

        /// <summary>
        /// 用户列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/UserPage")]
        public async Task<IActionResult> UserPage()
        {
            return View();
        }

        /// <summary>
        /// 新增、编辑标签页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/UserForm")]
        public async Task<IActionResult> UserForm()
        {
            return View();
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
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/User/BatchGetUserInfoList")]
        public async Task<SearchDto> BatchGetUserInfoList([FromQuery] SearchParameter parameter)
        {
            return await userDBService.QueryPage(parameter);
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

    }
}
