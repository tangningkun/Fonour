using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Repositories.Dependency;
using TsBlog.Repositories.PagedList;

namespace TsBlog.Repositories.Repository
{
    public class TsBlogGenericRepository<T> : IDependency, IRepository<T> where T : class, new()
    {
        public readonly TsBlogDbContext _dbContext;
        public TsBlogGenericRepository(TsBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual DbSet<T> db { get { return _dbContext.Set<T>(); } }

        public bool Delete(T entity)
        {
            db.Remove(entity);
            var result=_dbContext.SaveChanges();

        }

        public bool Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T FindById(object pkValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            throw new NotImplementedException();
        }

        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public long Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
