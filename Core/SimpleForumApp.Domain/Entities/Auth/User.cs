using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Domain.Entities.App;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public long PersonId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public Person Person { get; set; }
    }
}
