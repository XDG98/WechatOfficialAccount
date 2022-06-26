using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WechatOfficialAccount.Models;
using WechatOfficialAccount.Models.DTO;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Helper
{
    /// <summary>
    /// 网络请求辅助类
    /// </summary>
    public class HttpClienttHelper
    {
        public static readonly IHttpClientFactory httpClientFactory;
        static HttpClienttHelper()
        {
            httpClientFactory = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>();
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static async Task<Result> WeiXinGet(string url)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();

                object jsonResult = await httpClient.GetFromJsonAsync<object>(url);
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(jsonResult.ToString());
                if (weiXinResult.errcode != 0)
                {
                    result = new Fail(weiXinResult);
                }
                else
                {
                    result = new Success(jsonResult);
                }
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameter">请求参数</param>
        /// <returns></returns>
        public static async Task<Result> WeiXinPost(string url, string parameter)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();

                object jsonResult = await httpClient.PostAsJsonAsync<object>(url, parameter);
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(jsonResult.ToString());
                if (weiXinResult.errcode != 0)
                {
                    result = new Fail(weiXinResult);
                }
                else
                {
                    result = new Success(jsonResult);
                }
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static async Task<Result> Get(string url)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();

                object jsonResult = await httpClient.GetFromJsonAsync<object>(url);
                result = new Success(jsonResult);
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameter">请求参数</param>
        /// <returns></returns>
        public static async Task<Result> Post(string url, string parameter)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();

                object jsonResult = await httpClient.PostAsJsonAsync<object>(url, parameter);
                return new Success(jsonResult);
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }
    }
}
