using Core.Abstracts.Repositories;
using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toolbox.DataTools;

namespace Data.Repositories
{
    public class PersonRepository : ExtgenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Person> PeopleWithDepartment()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Person> ReadMany(Expression<Func<Person, bool>>? expression = null)
        {
            return base.ReadMany(expression);
        }
    }
}
