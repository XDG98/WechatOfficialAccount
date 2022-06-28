using Newtonsoft.Json;
using System.Net;
using WechatOfficialAccount.Controllers;
using WechatOfficialAccount.Helper;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using WechatOfficialAccount.Models.Parameter;
using WechatOfficialAccount.Services.Interface;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Services
{
    /// <summary>
    /// 自定义菜单服务
    /// </summary>
    public class SelfMenuService : MvcControllerBase, ISelfMenuService
    {
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <returns></returns>
        public async Task<Result> CreateMenu()
        {
            string url = $"{WeiXinApi}/menu/create?access_token={access_token}";
            #region 添加参数
            CreateMenuParameter createMenuParameter = new CreateMenuParameter()
            {
                button = new List<ButtonItem>()
                    {
                        #region 菜单一
                        new ButtonItem()
                        {
                            name = "菜单一",
                            sub_button = new List<Sub_buttonItem>()
                            {
                                new Sub_buttonItem()
                                {
                                    type = "view",
                                    name = "跳转网页",
                                    url = AppSettingsHelper.GetAppSettings("ImgUrl"),
                                },
                                new Sub_buttonItem()
                                {
                                    type = "click",
                                    name = "赞咱我们一下",
                                    key = "V1001_GOOD"
                                },
                                new Sub_buttonItem()
                                {
                                    type = "scancode_waitmsg",
                                    name = "扫码带提示",
                                    key = "rselfmenu_0_0"
                                },
                                new Sub_buttonItem()
                                {
                                    type = "scancode_push",
                                    name = "扫码推事件",
                                    key = "rselfmenu_0_1"
                                }
                            }
                        },
                        #endregion
                        #region 菜单二
                        new ButtonItem()
                        {
                            name = "菜单二",
                            sub_button = new List<Sub_buttonItem>()
                            {
                                new Sub_buttonItem()
                                {
                                    type = "pic_sysphoto",
                                    name = "系统拍照发图",
                                    key = "rselfmenu_1_0"
                                },
                                new Sub_buttonItem()
                                {
                                    type = "pic_photo_or_album",
                                    name = "拍照或者相册发图",
                                    key = "rselfmenu_1_1"
                                },
                                new Sub_buttonItem()
                                {
                                    type = "pic_weixin",
                                    name = "微信相册发图",
                                    key = "rselfmenu_1_2"
                                }
                            }
                        },
                        #endregion
                        #region 菜单三
                        new ButtonItem()
                        {
                            name = "菜单三",
                            sub_button = new List<Sub_buttonItem>()
                            {
                                new Sub_buttonItem()
                                {
                                    type = "location_select",
                                    name = "发送位置",
                                    key = "rselfmenu_2_0"
                                },
                                //new Sub_buttonItem()
                                //{
                                //    type = "media_id",
                                //    name = "图片",
                                //    media_id = "MEDIA_ID1"
                                //},
                                //new Sub_buttonItem()
                                //{
                                //    type = "view_limited",
                                //    name = "图文消息",
                                //    media_id = "MEDIA_ID2"
                                //},
                                //new Sub_buttonItem()
                                //{
                                //    type = "article_id",
                                //    name = "发布后的图文消息",
                                //    article_id = "ARTICLE_ID1"
                                //},
                                //new Sub_buttonItem()
                                //{
                                //    type = "article_view_limited",
                                //    name = "发布后的图文消息",
                                //    article_id = "ARTICLE_ID2"
                                //}
                            }
                        }
                        #endregion
                    }
            };
            #endregion
            Result result = await HttpClienttHelper.WeiXinPost(url, createMenuParameter);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
            }
            return result;
        }

        /// <summary>
        /// 查询自定义菜单
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetCurrentSelfmenuInfo()
        {
            string url = $"{WeiXinApi}/get_current_selfmenu_info?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetCurrentSelfmenuInfoDto getCurrentSelfmenuInfoDto = JsonConvert.DeserializeObject<GetCurrentSelfmenuInfoDto>(result.Data.ToString());
                result = new Success(getCurrentSelfmenuInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteMenu()
        {
            string url = $"{WeiXinApi}/menu/delete?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(result.Data.ToString());
                result = new Success(weiXinResult);
            }
            return result;
        }

        /// <summary>
        /// 获取自定义菜单配置
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetMenu()
        {
            string url = $"{WeiXinApi}/menu/get?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetCurrentSelfmenuInfoDto getCurrentSelfmenuInfoDto = JsonConvert.DeserializeObject<GetCurrentSelfmenuInfoDto>(result.Data.ToString());
                result = new Success(getCurrentSelfmenuInfoDto);
            }
            return result;
        }
    }
}
