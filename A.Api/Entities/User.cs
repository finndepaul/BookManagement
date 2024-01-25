using Microsoft.AspNetCore.Identity;

namespace Book.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
