using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.ViewModel.User
{
    /// <summary>
    /// 与领域用户实体对应的用户视图实体
    /// </summary>
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string EmailAddress { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public string Telephone { get; set; }
        public string Qq { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedIp { get; set; }
        public int LoginCount { get; set; }
        public DateTime? LatestLoginDate { get; set; }
        public string LatestLoginIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int Type { get; set; }
    }
}
