using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class Claim : BaseEntity
    {
        public long StatusId { get; set; }
        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<RoleClaim> Roles { get; set; }
    }
}
