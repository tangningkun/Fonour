﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fonour.Domin.IRepositories
{
    public interface IRepository
    {

    }
    /// <summary>
    /// 定义泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        //
        // 摘要:
        //     Gets count of all entities in this repository.
        //
        // 返回结果:
        //     Count of entities
        int Count();
        //
        // 摘要:
        //     Gets count of all entities in this repository based on given predicate.
        //
        // 参数:
        //   predicate:
        //     A method to filter count
        //
        // 返回结果:
        //     Count of entities
        int Count(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets count of all entities in this repository based on given predicate.
        //
        // 参数:
        //   predicate:
        //     A method to filter count
        //
        // 返回结果:
        //     Count of entities
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets count of all entities in this repository.
        //
        // 返回结果:
        //     Count of entities
        Task<int> CountAsync();
        //
        // 摘要:
        //     Deletes an entity.
        //
        // 参数:
        //   entity:
        //     Entity to be deleted
        void Delete(TEntity entity);
        //
        // 摘要:
        //     Deletes an entity by primary key.
        //
        // 参数:
        //   id:
        //     Primary key of the entity
        void Delete(TPrimaryKey id);
        //
        // 摘要:
        //     Deletes many entities by function. Notice that: All entities fits to given predicate
        //     are retrieved and deleted. This may cause major performance problems if there
        //     are too many entities with given predicate.
        //
        // 参数:
        //   predicate:
        //     A condition to filter entities
        void Delete(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Deletes an entity by primary key.
        //
        // 参数:
        //   id:
        //     Primary key of the entity
        Task DeleteAsync(TPrimaryKey id);
        //
        // 摘要:
        //     Deletes many entities by function. Notice that: All entities fits to given predicate
        //     are retrieved and deleted. This may cause major performance problems if there
        //     are too many entities with given predicate.
        //
        // 参数:
        //   predicate:
        //     A condition to filter entities
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Deletes an entity.
        //
        // 参数:
        //   entity:
        //     Entity to be deleted
        Task DeleteAsync(TEntity entity);
        //
        // 摘要:
        //     Gets an entity with given given predicate or null if not found.
        //
        // 参数:
        //   predicate:
        //     Predicate to filter entities
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets an entity with given primary key or null if not found.
        //
        // 参数:
        //   id:
        //     Primary key of the entity to get
        //
        // 返回结果:
        //     Entity or null
        TEntity FirstOrDefault(TPrimaryKey id);
        //
        // 摘要:
        //     Gets an entity with given given predicate or null if not found.
        //
        // 参数:
        //   predicate:
        //     Predicate to filter entities
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets an entity with given primary key or null if not found.
        //
        // 参数:
        //   id:
        //     Primary key of the entity to get
        //
        // 返回结果:
        //     Entity or null
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        //
        // 摘要:
        //     Gets an entity with given primary key.
        //
        // 参数:
        //   id:
        //     Primary key of the entity to get
        //
        // 返回结果:
        //     Entity
        TEntity Get(TPrimaryKey id);
        //
        // 摘要:
        //     Used to get a IQueryable that is used to retrieve entities from entire table.
        //
        // 返回结果:
        //     IQueryable to be used to select entities from database
        IQueryable<TEntity> GetAll();
        //
        // 摘要:
        //     Used to get a IQueryable that is used to retrieve entities from entire table.
        //     One or more
        //
        // 参数:
        //   propertySelectors:
        //     A list of include expressions.
        //
        // 返回结果:
        //     IQueryable to be used to select entities from database
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        //
        // 摘要:
        //     Used to get all entities based on given predicate.
        //
        // 参数:
        //   predicate:
        //     A condition to filter entities
        //
        // 返回结果:
        //     List of all entities
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Used to get all entities.
        //
        // 返回结果:
        //     List of all entities
        List<TEntity> GetAllList();
        //
        // 摘要:
        //     Used to get all entities based on given predicate.
        //
        // 参数:
        //   predicate:
        //     A condition to filter entities
        //
        // 返回结果:
        //     List of all entities
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Used to get all entities.
        //
        // 返回结果:
        //     List of all entities
        Task<List<TEntity>> GetAllListAsync();
        //
        // 摘要:
        //     Gets an entity with given primary key.
        //
        // 参数:
        //   id:
        //     Primary key of the entity to get
        //
        // 返回结果:
        //     Entity
        Task<TEntity> GetAsync(TPrimaryKey id);
        //
        // 摘要:
        //     Inserts a new entity.
        //
        // 参数:
        //   entity:
        //     Inserted entity
        TEntity Insert(TEntity entity);
        //
        // 摘要:
        //     Inserts a new entity and gets it's Id. It may require to save current unit of
        //     work to be able to retrieve id.
        //
        // 参数:
        //   entity:
        //     Entity
        //
        // 返回结果:
        //     Id of the entity
        TPrimaryKey InsertAndGetId(TEntity entity);
        //
        // 摘要:
        //     Inserts a new entity and gets it's Id. It may require to save current unit of
        //     work to be able to retrieve id.
        //
        // 参数:
        //   entity:
        //     Entity
        //
        // 返回结果:
        //     Id of the entity
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        //
        // 摘要:
        //     Inserts a new entity.
        //
        // 参数:
        //   entity:
        //     Inserted entity
        Task<TEntity> InsertAsync(TEntity entity);
        //
        // 摘要:
        //     Inserts or updates given entity depending on Id's value.
        //
        // 参数:
        //   entity:
        //     Entity
        TEntity InsertOrUpdate(TEntity entity);
        //
        // 摘要:
        //     Inserts or updates given entity depending on Id's value. Also returns Id of the
        //     entity. It may require to save current unit of work to be able to retrieve id.
        //
        // 参数:
        //   entity:
        //     Entity
        //
        // 返回结果:
        //     Id of the entity
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        //
        // 摘要:
        //     Inserts or updates given entity depending on Id's value. Also returns Id of the
        //     entity. It may require to save current unit of work to be able to retrieve id.
        //
        // 参数:
        //   entity:
        //     Entity
        //
        // 返回结果:
        //     Id of the entity
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
        //
        // 摘要:
        //     Inserts or updates given entity depending on Id's value.
        //
        // 参数:
        //   entity:
        //     Entity
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);





        //
        // 摘要:
        //     Gets count of all entities in this repository based on given predicate (use this
        //     overload if expected return value is greather than System.Int32.MaxValue).
        //
        // 参数:
        //   predicate:
        //     A method to filter count
        //
        // 返回结果:
        //     Count of entities
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets count of all entities in this repository (use if expected return value is
        //     greather than System.Int32.MaxValue.
        //
        // 返回结果:
        //     Count of entities
        long LongCount();
        //
        // 摘要:
        //     Gets count of all entities in this repository (use if expected return value is
        //     greather than System.Int32.MaxValue.
        //
        // 返回结果:
        //     Count of entities
        Task<long> LongCountAsync();
        //
        // 摘要:
        //     Gets count of all entities in this repository based on given predicate (use this
        //     overload if expected return value is greather than System.Int32.MaxValue).
        //
        // 参数:
        //   predicate:
        //     A method to filter count
        //
        // 返回结果:
        //     Count of entities
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets exactly one entity with given predicate. Throws exception if no entity or
        //     more than one entity.
        //
        // 参数:
        //   predicate:
        //     Entity
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Gets exactly one entity with given predicate. Throws exception if no entity or
        //     more than one entity.
        //
        // 参数:
        //   predicate:
        //     Entity
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // 摘要:
        //     Updates an existing entity.
        //
        // 参数:
        //   entity:
        //     Entity
        TEntity Update(TEntity entity);
        //
        // 摘要:
        //     Updates an existing entity.
        //
        // 参数:
        //   id:
        //     Id of the entity
        //
        //   updateAction:
        //     Action that can be used to change values of the entity
        //
        // 返回结果:
        //     Updated entity
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        //
        // 摘要:
        //     Updates an existing entity.
        //
        // 参数:
        //   id:
        //     Id of the entity
        //
        //   updateAction:
        //     Action that can be used to change values of the entity
        //
        // 返回结果:
        //     Updated entity
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        //
        // 摘要:
        //     Updates an existing entity.
        //
        // 参数:
        //   entity:
        //     Entity
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startPage">起始页</param>
        /// <param name="pageSize">页面条目</param>
        /// <param name="rowCount">数据总数</param>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order);

        void Save();

    }

    /// <summary>
    /// 默认Guid主键类型仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : Entity
    {

    }

}
