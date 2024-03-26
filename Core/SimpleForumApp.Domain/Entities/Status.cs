using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Claim> Claims { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
