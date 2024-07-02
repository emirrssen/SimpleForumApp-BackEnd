using Microsoft.EntityFrameworkCore;
using SimpleForumApp.Application.Repositories.PersonRepositories;
using SimpleForumApp.Domain.DTOs.App;
using SimpleForumApp.Persistence.EntityFrameworkCore.Context;

namespace SimpleForumApp.Persistence.EntityFrameworkCore.Repositories.PersonRepositories
{
    public class PersonReadRepository : ReadRepository, IPersonReadRepository
    {
        public PersonReadRepository(SimpleForumAppContext context) : base(context)
        {
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
    }
}
