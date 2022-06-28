using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WechatOfficialAccount.Models;
using static WechatOfficialAccount.Models.Result;

namespace WechatOfficialAccount.Helper
{
    /// <summary>
    /// AppSettings辅助类
    /// </summary>
    public class AppSettingsHelper
    {
        static IConfiguration Configuration { get; set; }
        static AppSettingsHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Add(new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    //ReloadOnChange = true; 当appsettings.json被修改时重新加载
                    ReloadOnChange = true
                })
                .Build();
        }

        /// <summary>
        /// 获取微信配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static string GetWeiXinConfig(params string[] sections)
        {
            List<string> configs = sections.ToList();
            configs.Insert(0, "WeiXinConfig");
            sections = configs.ToArray();
            return GetAppSettings(sections);
        }

        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static string GetSystemConfig(params string[] sections)
        {
            List<string> configs = sections.ToList();
            configs.Insert(0, "SystemConfig");
            sections = configs.ToArray();
            return GetAppSettings(sections);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static string GetAppSettings(params string[] sections)
        {
            var val = string.Empty;
            for (int i = 0; i < sections.Length; i++)
            {
                val += sections[i] + ":";
            }

            return Configuration[val.TrimEnd(':')];
        }

        /// <summary>
        /// 保存微信配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveWeiXinConfig(string key, string value)
        {
            return await SaveAppSettings(key, value, "WeiXinConfig");
        }
        /// <summary>
        /// 保存微信配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveWeiXinConfig(Dictionary<string, string> dataDic)
        {
            return await SaveAppSettings(dataDic, "WeiXinConfig");
        }

        /// <summary>
        /// 保存系统配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveSystemConfig(string key, string value)
        {
            return await SaveAppSettings(key, value, "SystemConfig");
        }
        /// <summary>
        /// 保存系统配置
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveSystemConfig(Dictionary<string, string> dataDic)
        {
            return await SaveAppSettings(dataDic, "SystemConfig");
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveAppSettings(string key, string value, params string[] sections)
        {
            Result result = new Result();
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                StreamReader streamReader = File.OpenText(filePath);
                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);

                var val = string.Empty;
                for (int i = 0; i < sections.Length; i++)
                {
                    val += sections[i] + ":";
                }
                key = val + key;

                jsonObject[key] = value;

                streamReader.Close();
                string contents = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, contents);
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sections">配置</param>
        /// <returns></returns>
        public static async Task<Result> SaveAppSettings(Dictionary<string, string> dataDic, params string[] sections)
        {
            Result result = new Result();
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                StreamReader streamReader = File.OpenText(filePath);
                JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
                JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);

                var val = string.Empty;
                for (int i = 0; i < sections.Length; i++)
                {
                    val += sections[i] + ":";
                }
                val = val.TrimEnd(':');

                foreach (var item in dataDic)
                {
                    jsonObject[val][item.Key] = item.Value;
                }

                streamReader.Close();
                string contents = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, contents);
                result = new Success();
            }
            catch (Exception ex)
            {
                result = new Fail(ex.Message);
            }
            return result;
        }

    }
}
