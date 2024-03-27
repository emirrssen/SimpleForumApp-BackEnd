using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class UserRole : EntityWithStat
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
        public Status Status { get; set; }
    }
}
