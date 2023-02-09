using Microsoft.AspNetCore.Identity;

namespace Core.Concrete.Entities
{
    public class AppRole : IdentityRole
    {
        public string? Detail { get; set; }
    }
}
