using Microsoft.AspNetCore.Identity;

namespace PestkitOnion.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
