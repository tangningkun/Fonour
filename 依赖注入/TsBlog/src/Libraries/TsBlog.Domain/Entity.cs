using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Domain
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public virtual TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public abstract class Entity : Entity<Guid>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
