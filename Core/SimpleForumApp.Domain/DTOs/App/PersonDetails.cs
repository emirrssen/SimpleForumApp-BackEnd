﻿using SimpleForumApp.Domain.Entities.Core;

namespace SimpleForumApp.Domain.DTOs.App
{
    public class PersonDetails : Entity
    {
        public long GenderId { get; set; }
        public long CountryId { get; set; }
        public string GenderName { get; set; }
        public string CountryName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }

    }
}
