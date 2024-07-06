﻿using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.App;
using SimpleForumApp.Domain.DTOs.App;
using SimpleForumApp.Domain.Entities.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.App
{
    public class PersonRepository : Repository, IPersonRepository
    {
        public PersonRepository(SimpleForumAppContext context) : base(context)
        {
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var personToDelete = await _context.Persons.FindAsync(id);

            if (personToDelete is null)
                return false;

            _context.Persons.Remove(personToDelete!);
            await SaveChangesAsync();

            return true;
        }

        public async Task<IList<PersonDetails>> GetAllPersonDetailsAsync()
        {
            var result = await _context.Persons
                    .Include(x => x.Gender)
                    .Include(x => x.Country)
                    .Select(person => new PersonDetails
                    {
                        Id = person.Id,
                        CountryId = person.CountryId,
                        GenderId = person.GenderId,
                        CountryName = person.Country.Name,
                        GenderName = person.Gender.Name,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        DateOfBirth = person.DateOfBirth,
                        ProfileImage = person.ProfileImage,
                        CreatedDate = person.CreatedDate,
                        UpdatedDate = person.UpdatedDate
                    }).AsNoTrackingWithIdentityResolution().ToListAsync();

            return result;
        }

        public async Task<long> InsertAsync(Person person)
        {
            var result = await _context.Persons.AddAsync(person);
            await SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
