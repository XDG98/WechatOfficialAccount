﻿using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Services
{
    /// <summary>
    /// 菜单栏管理服务
    /// </summary>
    public class NavBarService : INavBarService
    {
        /// <summary>
        /// 获取菜单栏列表
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetNavBarList()
        {
            Result result =  new Result();
            try
            {
                Dictionary<string, List<GetNavBarListDto>> navBarDtoDic = new Dictionary<string, List<GetNavBarListDto>>();
                navBarDtoDic.Add("基础支持", new List<GetNavBarListDto>()
            {
                new GetNavBarListDto() { Name = "设置账户信息", Icon = "person-circle", AspController = "Account", AspAction = "Index" },
                new GetNavBarListDto() { Name = "获取access_token", Icon = "shield-lock", AspController = "Account", AspAction = "GetAccessToken" },
                new GetNavBarListDto() { Name = "获取微信服务器IP地址", Icon = "pc", AspController = "Account", AspAction = "GetApiDomainIp" },
                new GetNavBarListDto() { Name = "获取微信服务器地址信息列表", Icon = "pc", AspController = "Account", AspAction = "IpAddressPage" },
            });
                navBarDtoDic.Add("菜单设置", new List<GetNavBarListDto>() { new GetNavBarListDto() { Name = "接口管理" }, new GetNavBarListDto() { Name = "事件推送" }, new GetNavBarListDto() { Name = "个性化菜单" } });
                navBarDtoDic.Add("消息设置", new List<GetNavBarListDto>() { new GetNavBarListDto() { Name = "消息推送" }, new GetNavBarListDto() { Name = "被动回复消息" }, new GetNavBarListDto() { Name = "消息模板" }, new GetNavBarListDto() { Name = "订阅消息" } });
                navBarDtoDic.Add("客服设置", new List<GetNavBarListDto>() { new GetNavBarListDto() { Name = "客服设置" } });
                navBarDtoDic.Add("用户管理", new List<GetNavBarListDto>()
            {
                new GetNavBarListDto() { Name = "用户分组管理", Icon = "", AspController = "User", AspAction = "Group" },
                new GetNavBarListDto() { Name = "获取用户列表", Icon = "", AspController = "User", AspAction = "Index" },
            });

                result = new Success(navBarDtoDic);
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }
    }
}
