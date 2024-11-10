using Microsoft.AspNetCore.Identity;

namespace SportyApp.Models
{
    public class AppUser: IdentityUser
    {
        public string Fullname {  get; set; } 
    }
}
