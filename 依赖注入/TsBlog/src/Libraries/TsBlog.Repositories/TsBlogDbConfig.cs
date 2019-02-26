﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories
{
    /// <summary>
    /// 静态管理数据库连接配置的类
    /// </summary>
    public static class TsBlogDbConfig
    {
        /// <summary>
        /// 数据库连接字符串(私有字段)
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["TsBlogMySQLDb"].ConnectionString;
        /// <summary>
        /// 数据库连接字符串(公有属性)
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
