using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
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
                httpClient.DefaultRequestHeaders.ConnectionClose = true;

                object jsonResult = await httpClient.GetFromJsonAsync<object>(url);
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(jsonResult.ToString());
                if (weiXinResult.errcode != 0)
                {
                    result = new Fail(WeiXinResultHandle.GetMessage(weiXinResult), weiXinResult);
                }
                else
                {
                    result = new Success(jsonResult);
                }
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameter">请求参数</param>
        /// <returns></returns>
        public static async Task<Result> WeiXinPost(string url, object parameter)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.ConnectionClose = true;

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(parameter), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync(url, stringContent);
                httpResponseMessage = await httpClient.PostAsync(url, stringContent);
                object jsonResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
                WeiXinResult weiXinResult = JsonConvert.DeserializeObject<WeiXinResult>(jsonResult.ToString());
                if (weiXinResult.errcode != 0)
                {
                    result = new Fail(WeiXinResultHandle.GetMessage(weiXinResult), weiXinResult);
                }
                else
                {
                    result = new Success(jsonResult);
                }
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
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
                httpClient.DefaultRequestHeaders.ConnectionClose = true;

                object jsonResult = await httpClient.GetFromJsonAsync<object>(url);
                result = new Success(jsonResult);
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameter">请求参数</param>
        /// <returns></returns>
        public static async Task<Result> Post(string url, object parameter)
        {
            Result result = new Result();
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.ConnectionClose = true;

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(parameter), Encoding.UTF8, "application/json");
                object jsonResult = await httpClient.PostAsJsonAsync<object>(url, stringContent);
                result = new Success(jsonResult);
            }
            catch (Exception ex)
            {
                result = new Error(ex.Message);
            }
            return result;
        }
    }
}
