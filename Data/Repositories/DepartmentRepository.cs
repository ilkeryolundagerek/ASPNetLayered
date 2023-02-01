using Core.Abstracts.Repositories;
using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Toolbox.DataTools;

namespace Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
