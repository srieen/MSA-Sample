namespace Person_Processor.Model
{    
    public class Person
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string?  Address { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }

    public class Person_SocialMedia
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string? SocialMediaType { get; set; }
        public string? Link { get; set; }
        
    }
}
