using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TsBlog.Domain;
using TsBlog.Repositories.Dependency;
using TsBlog.Repositories.Repository;
using AutoMapper;

namespace TsBlog.Services.AppServices
{
    public abstract class TsBlogAppService<TEntity> : ITsBlogAppService<TEntity>, IDependency where TEntity : Entity
    {
        private readonly IRepositiory<TEntity> _repositiory;

        protected TsBlogAppService(IRepositiory<TEntity> repositiory)
        {
            _repositiory = repositiory;
        }
        public async Task<List<TEntity>> GetAll()
        {
            var query = _repositiory.GetAll().ToList();
            return query;
            //var result = new List<TEntity>(
            //    query.Select(item => {
            //        var dto = Mapper.Map<TEntity>(item);
            //        return dto;
            //    })).ToList();
            //return result;
        }
    }
}
