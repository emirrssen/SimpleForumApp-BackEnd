using SimpleForumApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForumApp.Domain.Entities
{
    public class Person : BaseEntity
    {
        public long StatusId { get; set; }
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string NationalityNumber { get; set; }

        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public Country Country { get; set; }
        public User User { get; set; }
    }
}
