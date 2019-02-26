using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories
{

    /// <summary>
    /// 数据库工厂管理类
    /// </summary>
    public class TsBlogDbFactory
    {
        /// <summary>
        /// SqlSugarClient属性
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetSqlSugarClient()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = TsBlogDbConfig.ConnectionString, //必填
                DbType = DbType.MySql, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
            return db;
        }
    }
}
