using Person_API.Model;

namespace Person_API.Events
{
    public class NewPersonAdded
    {
        public Person Person { get; set; }
        public string Id { get; set; }

    }
}
