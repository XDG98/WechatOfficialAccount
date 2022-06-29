using System.ComponentModel;
using System.Xml;
using WechatOfficialAccount.Models;

namespace WechatOfficialAccount.Const
{
    public class WeiXinConst
    {
        /// <summary>
        /// 公众号搜索
        /// </summary>
        [Description("ADD_SCENE_SEARCH")]
        public const string ADD_SCENE_SEARCH = "公众号搜索";
        /// <summary>
        /// 公众号迁移
        /// </summary>
        [Description("ADD_SCENE_ACCOUNT_MIGRATION")]
        public const string ADD_SCENE_ACCOUNT_MIGRATION = "公众号迁移";
        /// <summary>
        /// 名片分享
        /// </summary>
        [Description("ADD_SCENE_PROFILE_CARD")]
        public const string ADD_SCENE_PROFILE_CARD = "名片分享";
        /// <summary>
        /// 扫描二维码
        /// </summary>
        [Description("ADD_SCENE_QR_CODE")]
        public const string ADD_SCENE_QR_CODE = "扫描二维码";
        /// <summary>
        /// 图文页内名称点击
        /// </summary>
        [Description("ADD_SCENE_PROFILE_LINK")]
        public const string ADD_SCENE_PROFILE_LINK = "图文页内名称点击";
        /// <summary>
        /// 图文页右上角菜单
        /// </summary>
        [Description("ADD_SCENE_PROFILE_ITEM")]
        public const string ADD_SCENE_PROFILE_ITEM = "图文页右上角菜单";
        /// <summary>
        /// 支付后关注
        /// </summary>
        [Description("ADD_SCENE_PAID")]
        public const string ADD_SCENE_PAID = "支付后关注";
        /// <summary>
        /// 微信广告
        /// </summary>
        [Description("ADD_SCENE_WECHAT_ADVERTISEMENT")]
        public const string ADD_SCENE_WECHAT_ADVERTISEMENT = "微信广告";
        /// <summary>
        /// 他人转载
        /// </summary>
        [Description("ADD_SCENE_REPRINT")]
        public const string ADD_SCENE_REPRINT = "他人转载";
        /// <summary>
        /// 视频号直播
        /// </summary>
        [Description("ADD_SCENE_LIVESTREAM")]
        public const string ADD_SCENE_LIVESTREAM = "视频号直播";
        /// <summary>
        /// 视频号
        /// </summary>
        [Description("ADD_SCENE_CHANNELS")]
        public const string ADD_SCENE_CHANNELS = "视频号";
        /// <summary>
        /// 其他
        /// </summary>
        [Description("ADD_SCENE_OTHERS")]
        public const string ADD_SCENE_OTHERS = "其他";

        public static Dictionary<int, WeiXinResult> weiXinErrCodeDic = new Dictionary<int, WeiXinResult>();
        public static void GetWeiXinErrCodeDic()
        {
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
                    weiXinErrCodeDic.Add(int.Parse(errCode.InnerText), new WeiXinResult { errcode = int.Parse(errCode.InnerText), errmsg = chineseDescription.InnerText });
                }
                else
                {
                    weiXinErrCodeDic.Add(int.Parse(errCode.InnerText), new WeiXinResult { errcode = int.Parse(errCode.InnerText), errmsg = englishDescription.InnerText });
                }
            }
        }
    }
}
