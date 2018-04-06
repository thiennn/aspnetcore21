using Microsoft.AspNetCore.Identity;

namespace AspNetCore21Demo.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
