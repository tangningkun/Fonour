using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Domain.Entities
{
    [SugarTable("users")]
    public class User:Entity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string Qq { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string WebsiteUrl { get; set; }
        
        /// <summary>
        /// 创建Ip
        /// </summary>
        public string CreatedIp { get; set; }
        /// <summary>
        /// 登录计数
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 最新登录日期
        /// </summary>
        public DateTime? LatestLoginDate { get; set; }
        /// <summary>
        /// 最后登录Ip
        /// </summary>
        public string LatestLoginIp { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
    }
}
