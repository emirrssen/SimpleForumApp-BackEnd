using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class RoleClaim : EntityWithStat
    {
        public long RoleId { get; set; }
        public long ClaimId { get; set; }
        public long StatusId { get; set; }

        public Role Role { get; set; }
        public Claim Claim { get; set; }
        public Status Status { get; set; }
    }
}
