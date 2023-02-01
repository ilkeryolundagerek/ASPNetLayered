using Core.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.DataTools;

namespace Data.Repositories
{
    public class ExtgenericRepository<T> : GenericRepository<T>, IExtGenericRepository<T> where T : class
    {
        public ExtgenericRepository(DbContext context) : base(context)
        {
        }
    }
}
