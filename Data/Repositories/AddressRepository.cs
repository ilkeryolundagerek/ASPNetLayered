using Core.Abstracts.Repositories;
using Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Toolbox.DataTools;

namespace Data.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }
    }
}
