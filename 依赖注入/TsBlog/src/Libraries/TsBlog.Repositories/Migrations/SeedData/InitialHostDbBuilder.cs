using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TsBlogDbContext _context;

        public InitialHostDbBuilder(TsBlogDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
