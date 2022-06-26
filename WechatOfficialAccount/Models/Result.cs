using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WechatOfficialAccount.Models
{
    public class Result
    {
        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// 响应数据
        /// </summary>
        public object Data { get; set; } = new object();

        #region 请求响应
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public class Success : Result
        {
            public Success()
            {
                this.Code = HttpStatusCode.OK;
                this.Message = "ok";
                this.Data = new object();
            }
            public Success(string info)
            {
                this.Code = HttpStatusCode.OK;
                this.Message = info;
                this.Data = new object();
            }
            public Success(object data)
            {
                this.Code = HttpStatusCode.OK;
                this.Message = "ok";
                this.Data = data;
            }
            public Success(string info, object data)
            {
                this.Code = HttpStatusCode.OK;
                this.Message = info;
                this.Data = data;
            }
        }

        /// <summary>
        /// 失败
        /// </summary>
        public class Fail : Result
        {
            public Fail()
            {
                this.Code = HttpStatusCode.BadRequest;
                this.Message = "fail";
                this.Data = new object();
            }
            public Fail(string info)
            {
                this.Code = HttpStatusCode.BadRequest;
                this.Message = info;
                this.Data = new object();
            }
            public Fail(object data)
            {
                this.Code = HttpStatusCode.BadRequest;
                this.Message = "fail";
                this.Data = data;
            }
            public Fail(string info, object data)
            {
                this.Code = HttpStatusCode.BadRequest;
                this.Message = info;
                this.Data = data;
            }
        }
        #endregion

        /// <summary>
        /// 带操作日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        //protected virtual ActionResult Success(string info, string title, OperationType type, string keyValue, string content, string datetimeformats = null)
        //{
        //    OperateLogModel operateLogModel = new OperateLogModel();
        //    operateLogModel.title = title;
        //    operateLogModel.type = type;
        //    operateLogModel.url = (string)WebHelper.GetHttpItems("currentUrl");
        //    operateLogModel.sourceObjectId = keyValue;
        //    operateLogModel.sourceContentJson = content;

        //    OperatorHelper.Instance.WriteOperateLog(operateLogModel);

        //    return ToJsonResult(new ResParameter { code = ResponseCode.success, message = info, data = new object { } }, datetimeformats);
        //}
    }
}
