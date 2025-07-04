using Microsoft.AspNetCore.Identity;

namespace Assignments.Models
{
    public class ApplicationUser: IdentityUser
    {

        public string? Address { get; set; }
    }
}
