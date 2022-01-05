using Person_Processor.Model;

namespace Person_Processor.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> AddSocialMediaDetails(Person_SocialMedia personSocialMedia, string correlationId);
                
    }
}