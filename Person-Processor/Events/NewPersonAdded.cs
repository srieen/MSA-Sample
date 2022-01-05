using Person_Processor.Model;

namespace Person_Processor.Events
{
    public class NewPersonAdded
    {
        public Person Person { get; set; }
        public string Id { get; set; }

    }
}
