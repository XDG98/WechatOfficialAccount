using SqlSugar;
using WechatOfficialAccount.Helper;

namespace WechatOfficialAccount.Models
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public static class DBConnection
    {
        public static readonly SqlSugarScope sqlSugarScope;
        public static readonly string connectionString = AppSettingsHelper.GetAppSettings("ConnectionStrings", "ConnectionString");
        static DBConnection()
        {
            ConnectionConfig connectionConfig = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            };
            sqlSugarScope = new SqlSugarScope(connectionConfig);
        }

        public static bool GetConnectionStatus()
        {
            return sqlSugarScope.Ado.IsValidConnection();
        }

    }
}
