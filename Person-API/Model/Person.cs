namespace Person_API.Model
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
}
