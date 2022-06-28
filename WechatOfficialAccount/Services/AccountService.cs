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
    /// 账户管理服务
    /// </summary>
    public class AccountService : MvcControllerBase, IAccountService
    {
        /// <summary>
        /// 设置账户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Result> SetAccountInfo(SetAccountInfoParameter data)
        {
            Result result = new Result();
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            if (appid != data.appid)
            {
                dataDic.Add("appid", data.appid);
            }
            if (appsecret != data.appsecret)
            {
                dataDic.Add("appsecret", data.appsecret);
            }
            if (dataDic.Count > 0)
            {
                result = await AppSettingsHelper.SaveWeiXinConfig(dataDic);
            }
            return result;
        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetAccessToken()
        {
            string url = $"{WeiXinApi}/token?grant_type=client_credential&appid={appid}&secret={appsecret}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetAccessTokenDto getAccessTokenDto = JsonConvert.DeserializeObject<GetAccessTokenDto>(result.Data.ToString());
                Dictionary<string, string> dataDic = new Dictionary<string, string>();
                dataDic.Add("access_token", getAccessTokenDto.access_token);
                dataDic.Add("expires_in", DateTime.Now.AddSeconds(getAccessTokenDto.expires_in).ToString());
                await AppSettingsHelper.SaveWeiXinConfig(dataDic);
                result = new Success(getAccessTokenDto);
            }
            return result;
        }

        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetApiDomainIp()
        {
            string url = $"{WeiXinApi}/get_api_domain_ip?access_token={access_token}";
            Result result = await HttpClienttHelper.WeiXinGet(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetApiDomainIpDto getApiDomainIpDto = JsonConvert.DeserializeObject<GetApiDomainIpDto>(result.Data.ToString());
                result = new Success(getApiDomainIpDto);
            }
            return result;
        }

        /// <summary>
        /// 根据IP获取物理地址
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        public async Task<Result> GetIpAddress(string ip)
        {
            string url = $"http://ip-api.com/json/{ip}?lang=zh-CN";
            Result result = await HttpClienttHelper.Get(url);
            if (result.Code == HttpStatusCode.OK)
            {
                GetIpAddressDto getIpAddressDto = JsonConvert.DeserializeObject<GetIpAddressDto>(result.Data.ToString());
                //JObject jobject = (JObject)result.Data;
                //var country = jobject["country"];
                //var city = jobject["city"];

                result = new Success(getIpAddressDto);
            }
            return result;
        }

        /// <summary>
        /// 获取微信服务器地址信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<Result> GetIpAddressList()
        {
            Result result = await GetApiDomainIp();
            if (result.Code == HttpStatusCode.OK)
            {
                List<GetIpAddressDto> getIpAddressDtoList = new List<GetIpAddressDto>();
                GetApiDomainIpDto getApiDomainIpDto = result.Data as GetApiDomainIpDto;
                foreach (var item in getApiDomainIpDto.ip_list)
                {
                    result = await GetIpAddress(item);
                    if (result.Code == HttpStatusCode.OK)
                    {
                        getIpAddressDtoList.Add((GetIpAddressDto)result.Data);
                    }
                }
                result = new Success(getIpAddressDtoList);
            }
            return result;
        }

    }
}
