using Microsoft.AspNetCore.Identity;
using SimpleForumApp.Domain.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
