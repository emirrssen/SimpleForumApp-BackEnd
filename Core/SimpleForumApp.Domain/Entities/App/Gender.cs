using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Gender : EntityWithId
    {
        public long StatusId { get; set; }
        public string Name { get; set; }

        public Status Status { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
