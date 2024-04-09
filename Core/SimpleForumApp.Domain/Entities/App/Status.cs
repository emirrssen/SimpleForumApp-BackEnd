using SimpleForumApp.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities.App
{
    public class Status : Entity
    {
        public string Name { get; set; }

        public ICollection<Gender> Genders { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
