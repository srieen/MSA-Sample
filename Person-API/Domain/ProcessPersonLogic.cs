using Person_API.Interfaces;
using Person_API.Model;

namespace Person_API.Domain
{
    public class ProcessPersonLogic : IProcessPersonLogic
    {
        private readonly IPersonRepository _personRepository;
        private readonly INewPersonAddedNotification _newPersonAddedNotification;

        public ProcessPersonLogic(IPersonRepository personRepository, INewPersonAddedNotification newPersonAddedNotification)
        {
            _personRepository = personRepository;
            _newPersonAddedNotification = newPersonAddedNotification;
        }


        public async Task<bool> AddPerson(Person person, string correlationId, CancellationToken cancellationToken)
        {
            var a = await _personRepository.AddPerson(person, correlationId, cancellationToken);

            var b = _newPersonAddedNotification.NewPersonAdded(person, correlationId);

            return a;
        }

        public async Task<List<Person>> GetAllPersons(string correlationId, CancellationToken cancellationToken)
        {
            var personsList = await _personRepository.GetAllPersons(correlationId,cancellationToken);

            return personsList;
        }
    }
}
