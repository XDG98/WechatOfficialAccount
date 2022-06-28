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

        /// <summary>
        /// 根据微信错误码获取微信提示
        /// </summary>
        /// <param name="weiXinResult"></param>
        /// <returns></returns>
        public static string GetMessage(WeiXinResult weiXinResult)
        {
            if (WeiXinConst.weiXinErrCodeDic.ContainsKey(weiXinResult.errcode))
            {
                return WeiXinConst.weiXinErrCodeDic[weiXinResult.errcode].errmsg;
            }
            else
            {
                return weiXinResult.errmsg;
            }
        }
    }

}
