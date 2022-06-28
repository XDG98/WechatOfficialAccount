namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 获取自定义菜单Dto
    /// </summary>
    public class GetCurrentSelfmenuInfoDto
    {
        /// <summary>
        /// 菜单是否开启，0代表未开启，1代表开启
        /// </summary>
        public int is_menu_open { get; set; }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public Selfmenu_info selfmenu_info { get; set; }
    }
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class Selfmenu_info
    {
        /// <summary>
        /// 菜单按钮
        /// </summary>
        public List<ButtonItemDto> button { get; set; }
    }
    /// <summary>
    /// 菜单按钮
    /// </summary>
    public class ButtonItemDto
    {
        /// <summary>
        /// 菜单一
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 二级菜单按钮
        /// </summary>
        public Sub_button sub_button { get; set; }
    }
    /// <summary>
    /// 二级菜单按钮
    /// </summary>
    public class Sub_button
    {
        /// <summary>
        /// 按钮内容
        /// </summary>
        public List<ListItem> list { get; set; }
    }
    /// <summary>
    /// 按钮内容
    /// </summary>
    public class ListItem
    {
        /// <summary>
        /// 菜单的类型，公众平台官网上能够设置的菜单类型有view（跳转网页）、
        /// text（返回文本，下同）、img、photo、video、voice。
        /// 使用 API 设置的则有8种，详见《自定义菜单创建接口》
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string url { get; set; }
    }
    
}
