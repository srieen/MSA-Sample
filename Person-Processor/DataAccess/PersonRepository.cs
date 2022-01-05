using Person_Processor.Interfaces;
using Person_Processor.Model;
using System.Data;

namespace Person_Processor.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _dbContext;

        public PersonRepository(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddSocialMediaDetails(Person_SocialMedia personSocialMedia, string correlationId)
        {

            await _dbContext.Person_SocialMedia.AddAsync(personSocialMedia);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
