using System.Xml;
using WechatOfficialAccount.Const;

namespace WechatOfficialAccount.Models
{
    /// <summary>
    /// 微信响应结果
    /// </summary>
    public class WeiXinResult
    {
        /// <summary>
        /// 响应错误码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 响应错误信息
        /// </summary>
        public string errmsg { get; set; }

        

    }

    public static class WeiXinResultHandle
    {
        public static Dictionary<int, WeiXinResult> weiXinErrCodeDic;
        static WeiXinResultHandle()
        {
            weiXinErrCodeDic = GetWeiXinErrCodeDic();
        }
        
        /// <summary>
        /// 根据微信错误码获取微信提示
        /// </summary>
        /// <param name="weiXinResult"></param>
        /// <returns></returns>
        public static string GetMessage(WeiXinResult weiXinResult)
        {
            if (weiXinErrCodeDic.ContainsKey(weiXinResult.errcode))
            {
                string errmsg = weiXinErrCodeDic[weiXinResult.errcode].errmsg;
                if (!string.IsNullOrEmpty(errmsg))
                {
                    return $"{weiXinResult.errcode}：{errmsg}";
                }
            }
            return $"{weiXinResult.errcode}：{weiXinResult.errmsg}";
        }

        /// <summary>
        /// 获取微信错误码字典
        /// </summary>
        public static Dictionary<int, WeiXinResult> GetWeiXinErrCodeDic()
        {
            Dictionary<int, WeiXinResult> dic = new Dictionary<int, WeiXinResult>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Path.Combine(AppContext.BaseDirectory, "wwwroot\\File\\WeiXinErrCode.xml"));
            //获取xml根节点
            XmlNode xmlRoot = xmlDocument.DocumentElement;
            //读取第一个Row节点
            XmlNodeList xmlNodeList = xmlRoot.SelectNodes("Row");
            foreach (var xmlNode in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;
                XmlNode errCode = xmlElement.SelectSingleNode("ErrCode");
                XmlNode englishDescription = xmlElement.SelectSingleNode("EnglishDescription");
                XmlNode chineseDescription = xmlElement.SelectSingleNode("ChineseDescription");
                if (!string.IsNullOrEmpty(chineseDescription.InnerText))
                {
                    dic.Add(int.Parse(errCode.InnerText), new WeiXinResult { errcode = int.Parse(errCode.InnerText), errmsg = chineseDescription.InnerText });
                }
                else
                {
                    dic.Add(int.Parse(errCode.InnerText), new WeiXinResult { errcode = int.Parse(errCode.InnerText), errmsg = englishDescription.InnerText });
                }
            }

            return dic;
        }
    }

}
