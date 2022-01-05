using Person_API.Model;

namespace Person_API.Interfaces
{
    public interface INewPersonAddedNotification
    {
        Task<bool> NewPersonAdded(Person person, string Id);
    }
}