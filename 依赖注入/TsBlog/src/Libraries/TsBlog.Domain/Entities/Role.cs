using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Domain.Entities
{
    [SugarTable("Roles")]
    public class Role:Entity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleId { get; set;}
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid CreateUserId { get; set; }
        /// <summary>
        /// 角色备注
        /// </summary>
        public string Remarks { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
