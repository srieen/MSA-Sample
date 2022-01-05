using Person_API.Model;

namespace Person_API.Interfaces
{
    public interface IProcessPersonLogic
    {
        Task<bool> AddPerson(Person person, string correlationId, CancellationToken cancellationToken);
        Task<List<Person>> GetAllPersons(string correlationId, CancellationToken cancellationToken);
    }
}