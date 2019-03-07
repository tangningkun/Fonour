using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Services.AppServices
{
    public interface ITsBlogAppService<TEntity>
    {
        Task<List<TEntity>> GetAll();
    }
}
