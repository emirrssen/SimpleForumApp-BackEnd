using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public long StatusId { get; set; }
        public long PersonId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Status Status { get; set; }
        public Person Person { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
