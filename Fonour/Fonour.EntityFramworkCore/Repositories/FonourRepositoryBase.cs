﻿using Fonour.Domin;
using Fonour.Domin.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fonour.EntityFramworkCore.Repositories
{
    public abstract class FonourRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        public virtual DbSet<TEntity> Table { get { return _dbContext.Set<TEntity>(); } }

        //定义数据访问上下文对象
        protected readonly FonourDbContext _dbContext;

        /// <summary>
        /// 通过构造函数注入得到数据上下文对象实例
        /// </summary>
        /// <param name="dbContext"></param>
        public FonourRepositoryBase(FonourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region 其他
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        public int Count()
        {
            return GetAll().Count();
        }
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).CountAsync();
        }
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
                /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体得数量</returns>
        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
                /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <returns>实体得数量</returns>

        public long LongCount()
        {
            return GetAll().LongCount();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
        /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <returns>实体得数量</returns>
        public async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
        /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体得数量</returns>
        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await GetAll().Where(predicate).LongCountAsync();
        }
        #endregion


        #region 删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);

            Table.Remove(entity);
            Save();
        }
        /// <summary>
        /// 按主键删除实体
        /// </summary>
        /// <param name="id">实体的主键</param>
        public void Delete(TPrimaryKey id)
        {
            AttachIfNot(Get(id));
            Table.Remove(Get(id));
            Save();
        }
        /// <summary>
        /// 按功能删除许多实体。 请注意：所有实体都适合给定的谓词
        /// 被检索并删除。 如果存在这可能会导致严重的性能问题
        /// 包含给定谓词的实体太多了
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Table.Where(predicate).ToList().ForEach(item => _dbContext.Set<TEntity>().Remove(item));
            Save();
        }
        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="where">lambda表达式</param>
        /// <param name="autoSave">是否自动保存</param>
        public void Delete(Expression<Func<TEntity, bool>> expression, bool autoSave = true)
        {
            Table.Where(expression).ToList().ForEach(item => _dbContext.Set<TEntity>().Remove(item));
            if (autoSave)
                Save();
        }
        /// <summary>
        /// 按主键删除实体
        /// </summary>
        /// <param name="id">实体的主键</param>
        public async Task DeleteAsync(TPrimaryKey id)
        {
            await Task.Run(() => Table.Remove(Get(id)));
        }
        /// <summary>
        /// 按功能删除许多实体。 请注意：所有实体都适合给定的谓词
        /// 被检索并删除。 如果存在这可能会导致严重的性能问题
        /// 包含给定谓词的实体太多了
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in await GetAll().Where(predicate).ToListAsync())
            {
                Delete(entity);
            }
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除实体</param>
        /// <returns></returns>
        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }
        #endregion


        #region 查询
        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        public TEntity Get(TPrimaryKey id)
        {
            return Table.Where(d => d.Id.Equals(id)).FirstOrDefault();
            //return Table.FirstOrDefault(CreateEqualityExpressionForId(id));
        }
        /// <summary>
        /// 用于获取用于从整个表中检索实体的IQueryable。
        /// </summary>
        /// <returns>IQueryable用于从数据库中选择实体</returns>
        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        /// <summary>
        /// 用于获取用于从整个表中检索实体的IQueryable一个或多个
        /// </summary>
        /// <param name="propertySelectors">包含表达式的列表</param>
        /// <returns>IQueryable用于从数据库中选择实体</returns>
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors==null)
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }
        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }
        /// <summary>
        /// 用于获取所有实体
        /// </summary>
        /// <returns>实体</returns>
        public List<TEntity> GetAllList()
        {
            return Table.ToList();
        }
        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();

        }
        /// <summary>
        /// 用于获取所有实体
        /// </summary>
        /// <returns>实体</returns>
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await Table.ToListAsync();
        }
        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体</returns>
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await Table.Where(d => d.Id.Equals(id)).FirstAsync();
        }
        #endregion


        #region 插入
        //
        // 摘要:
        //     Inserts a new entity.
        //
        // 参数:
        //   entity:
        //     Inserted entity

        public TEntity Insert(TEntity entity)
        {
            var result = Table.Add(entity);
            return result.Entity;
        }
        /// <summary>
        /// 插入一个新实体并获取它的ID。 可能需要保存当前单位
        /// 能够检索id
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>实体Id</returns>
        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        /// <summary>
        /// 插入一个新实体并获取它的ID。 可能需要保存当前单位能够检索id
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回实体得ID</returns>
        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
        /// <summary>
        /// 插入一个新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>插入的实体</returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await Table.AddAsync(entity);
            return result.Entity;
        }
        /// <summary>
        /// 根据Id的值插入或更新给定实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>实体</returns>
        public TEntity InsertOrUpdate(TEntity entity)
        {
            if (Get(entity.Id) != null)
                return Update(entity);
            return Insert(entity);
        }
        /// <summary>
        /// 根据Id的值插入或更新给定实体.也返回的Id
        /// 实体.可能需要保存当前工作单元才能检索id。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回实体ID</returns>
        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        /// <summary>
        /// 根据Id的值插入或更新给定实体.也返回的Id
        /// 实体.可能需要保存当前工作单元才能检索id。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回实体得ID</returns>
        public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
        /// <summary>
        /// 根据Id的值插入或更新给定实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>实体</returns>
        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            if (Get(entity.Id) != null)
                return await UpdateAsync(entity);
            return await InsertAsync(entity);
        }
        #endregion


        #region 获得单个实体
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);

        }
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">谓词来过滤实体</param>
        /// <returns>实体或null</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体或null/returns>
        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return Table.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await GetAll().FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await Table.Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
        }

        #endregion


        #region 更新
        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新的实体</returns>
        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            //dbContext.Configuration.AutoDetectChangesEnabled = true;
            var _model = Table.Where(d => d.Id.Equals(id)).FirstOrDefault();
            updateAction(_model);
            return Get(id);
        }
        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="id">实体的ID</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新了实体</returns>
        public async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var _model = await Table.Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
            await updateAction(_model);
            return Get(id);
        }
        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>更新的实体</returns>
        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }
        #endregion

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="startPage">页码</param>
        /// <param name="pageSize">单页数据数</param>
        /// <param name="rowCount">行数</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null)
        {
            var result = from p in Table
                         select p;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.Id);
            rowCount = result.Count();
            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 事务性保存
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }
    }

    /// <summary>
    /// 主键为Guid类型的仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class FonourRepositoryBase<TEntity> : FonourRepositoryBase<TEntity, Guid> where TEntity : Entity
    {
        public FonourRepositoryBase(FonourDbContext dbContext) : base(dbContext)
        {
        }
    }
}
