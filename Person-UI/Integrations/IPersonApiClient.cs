using Person_UI.Model;

namespace Person_UI.Integrations
{
    public interface IPersonApiClient
    {
        Task<bool> AddPerson(Person person);

        Task<List<Person>> GetAllPersons();
    }
}
