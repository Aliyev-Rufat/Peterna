using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }
}
