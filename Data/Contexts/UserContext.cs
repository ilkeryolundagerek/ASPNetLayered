using Core.Concrete.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class UserContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
    }
}
