using Core.Abstracts.Repositories;
using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.DataTools;

namespace Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
