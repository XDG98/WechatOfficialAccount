using System.ComponentModel;
using System.Reflection;
using WechatOfficialAccount.Models;

namespace WechatOfficialAccount.Helper
{
    public class EnumHelper
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetEnumDescription(System.Enum en)
        {
            //获取类型
            Type type = en.GetType();
            //获取成员
            MemberInfo[] memberInfos = type.GetMember(en.ToString());
            if (memberInfos != null && memberInfos.Length > 0)
            {
                //获取描述特性
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attrs!=null && attrs.Length > 0)
                {
                    //返回当前描述
                    return attrs[0].Description;
                }
            }
            return en.ToString();
        }

        /// <summary>
        /// 获取枚举项
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static List<EnumDto> GetEnumDescriptionList(string enumName)
        {
            var ems = GetEnums(enumName);
            Type value = null;
            string name = enumName.Substring(enumName.LastIndexOf(".") + 1);
            var inst = ems.TryGetValue(name, out value);
            var listDic = inst ? EnumToList(value) : new List<EnumDto>();
            return listDic;
        }

        /// <summary>
        /// 获取所有枚举
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static Dictionary<string, Type> GetEnums(string enumName)
        {
            Dictionary<string, Type> m_enums = new Dictionary<string, Type>();
            if (m_enums.Count > 0)
                return m_enums;

            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in ass)
            {
                if (!item.FullName.StartsWith("WechatOfficialAccount"))
                    continue;

                var types = item.GetTypes().ToList();
                string className = enumName.Substring(0, enumName.IndexOf("."));
                var ems = types.FindAll(x => x.IsEnum && x.FullName.Contains(className));
                if (null != ems && ems.Count > 0)
                {
                    foreach (var em in ems)
                    {
                        m_enums[em.Name] = em;
                    }
                }
            }
            return m_enums;
        }

        /// <summary>
        /// 枚举转List
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<EnumDto> EnumToList(Type type)
        {
            List<EnumDto> enumDtoList = new List<EnumDto>();

            System.Array arrays = System.Enum.GetValues(type);
            for (int i = 0; i < arrays.Length; i++)
            {
                EnumDto enumDto = new EnumDto() { Value = (int)arrays.GetValue(i), };

                Type enumType = arrays.GetValue(i).GetType();
                // 获取枚举常数名称。
                string name = System.Enum.GetName(enumType, arrays.GetValue(i));
                enumDto.Key = name;
                if (name != null)
                {
                    // 获取枚举字段。
                    FieldInfo fieldInfo = enumType.GetField(name);
                    if (fieldInfo != null)
                    {
                        // 获取描述的属性。
                        DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                            typeof(DescriptionAttribute), false) as DescriptionAttribute;
                        if (attr != null)
                        {
                            enumDto.Description = attr.Description;
                        }
                    }
                }

                enumDtoList.Add(enumDto);
            }
            return enumDtoList;
        }
    }
}
