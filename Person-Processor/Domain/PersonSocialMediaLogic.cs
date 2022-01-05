using Person_Processor.Interfaces;
using Person_Processor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Processor.Domain
{
    public class PersonSocialMediaLogic : IPersonSocialMediaLogic
    {
        private readonly IPersonRepository _personRepository;

        public PersonSocialMediaLogic(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> AddSocialMediaData(Person person, string correlationId)
        {
            string link = $"http://facebook.com/{person.FirstName}.{person.LastName}";

            var personSocialMedia = new Person_SocialMedia() {  PersonId = person.Id, SocialMediaType = "Facebook" , Link = link };

            var r = await _personRepository.AddSocialMediaDetails(personSocialMedia, correlationId);

            return r;
        }
    }
}
