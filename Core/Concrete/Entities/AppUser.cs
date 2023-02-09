using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
    }
}
