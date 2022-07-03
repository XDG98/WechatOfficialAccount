﻿using System.ComponentModel;

namespace WechatOfficialAccount.Enum
{
    public class WeiXinEnum
    {
        public enum Sex
        {
            /// <summary>
            /// 男
            /// </summary>
            [Description("男")]
            Male = 0,
            /// <summary>
            /// 女
            /// </summary>
            [Description("女")]
            Female = 1,
        }

        public enum ResultEnum
        {
            /// <summary>
            /// 1
            /// </summary>
            [Description("1")]
            Male = 1,
            /// <summary>
            /// 2
            /// </summary>
            [Description("2")]
            Female = 2,
        }
    }
}
