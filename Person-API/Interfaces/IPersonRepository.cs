using Person_API.Model;

namespace Person_API.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> AddPerson(Person person, string correlationId, CancellationToken cancellationToken);

        Task<List<Person>> GetAllPersons(string correlationId, CancellationToken cancellationToken);

        Task<Person> GetPersonByName(string fristName, string lastName , string dateOfBirth, 
            string correlationId, CancellationToken cancellationToken);
    }
}