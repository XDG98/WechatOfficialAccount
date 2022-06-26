namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 根据IP获取物理地址Dto
    /// </summary>
    public class GetIpAddressDto
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 国家编码
        /// </summary>
        public string countryCode { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string regionName { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string zip { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double lon { get; set; }
        /// <summary>
        /// 时区
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 组织
        /// </summary>
        public string org { get; set; }
        //public string as { get; set; }
        /// <summary>
        /// 查询
        /// </summary>
        public string query { get; set; }
    }
}
