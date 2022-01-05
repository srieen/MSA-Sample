
using Person_Processor.Model;

namespace Person_Processor.Interfaces
{
    public interface IPersonSocialMediaLogic
    {
        Task<bool> AddSocialMediaData(Person person, string correlationId);
    }
}