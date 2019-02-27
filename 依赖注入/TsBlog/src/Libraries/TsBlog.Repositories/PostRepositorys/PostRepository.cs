using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Repository;

namespace TsBlog.Repositories.PostRepositorys
{
    /// <summary>
    /// POST表的数据库操作类
    /// </summary>
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            using (var db = TsBlogDbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().OrderBy(x => x.Id, OrderByType.Desc).Take(limit).ToList();
                return list;
            }
        }
    }
    /// <summary>
    /// POST表的数据库操作类
    /// </summary>
    //public class PostRepository : IPostRepository
    //{
    //    /// <summary>
    //    /// 根据ID查询
    //    /// </summary>
    //    /// <param name="id">Post ID</param>
    //    /// <returns></returns>
    //    public Post FindById(int id)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var entity = db.Queryable<Post>().Single(x => x.Id == id);
    //            return entity;
    //        }
    //    }

    //    /// <summary>
    //    /// 查询所有数据(无分页,大数量时请慎用)
    //    /// </summary>
    //    /// <returns></returns>
    //    public IEnumerable<Post> FindAll()
    //    {
    //        #region SqlSugar读取方式
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var list = db.Queryable<Post>().ToList();
    //            return list;
    //        }
    //        #endregion
    //    }


    //    /// <summary>
    //    /// 写入实体数据
    //    /// </summary>
    //    /// <param name="entity">博文实体类</param>
    //    /// <returns></returns>
    //    public int Insert(Post entity)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var i = db.Insertable(entity).ExecuteReturnBigIdentity();
    //            //返回的i是long类型,这里你可以根据你的业务需要进行处理
    //            return (int)i;
    //        }
    //    }

    //    /// <summary>
    //    /// 更新实体数据
    //    /// </summary>
    //    /// <param name="entity">博文实体类</param>
    //    /// <returns></returns>
    //    public bool Update(Post entity)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            //这种方式会以主键为条件
    //            var i = db.Updateable(entity).ExecuteCommand();
    //            return i > 0;
    //        }
    //    }

    //    /// <summary>
    //    /// 根据实体删除一条数据
    //    /// </summary>
    //    /// <param name="entity">博文实体类</param>
    //    /// <returns></returns>
    //    public bool Delete(Post entity)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var i = db.Deleteable(entity).ExecuteCommand();
    //            return i > 0;
    //        }
    //    }

    //    /// <summary>
    //    /// 删除指定ID的数据
    //    /// </summary>
    //    /// <param name="id">主键ID</param>
    //    /// <returns></returns>
    //    public bool DeleteById(object id)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var i = db.Deleteable<Post>(id).ExecuteCommand();
    //            return i > 0;
    //        }
    //    }

    //    /// <summary>
    //    /// 删除指定ID集合的数据(批量删除)
    //    /// </summary>
    //    /// <param name="ids">主键ID集合</param>
    //    /// <returns></returns>
    //    public bool DeleteByIds(object[] ids)
    //    {
    //        using (var db = TsBlogDbFactory.GetSqlSugarClient())
    //        {
    //            var i = db.Deleteable<Post>().In(ids).ExecuteCommand();
    //            return i > 0;
    //        }
    //    }
    //}
}
