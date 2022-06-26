namespace WechatOfficialAccount.Models.DTO
{
    public class GetNavBarListDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// 控制器
        /// </summary>
        public string AspController { get; set; } = "Home";
        /// <summary>
        /// 方法
        /// </summary>
        public string AspAction { get; set; } = "NotFound";
    }
}
