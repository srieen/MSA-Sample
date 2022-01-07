using Microsoft.AspNetCore.Mvc.RazorPages;
using Person_UI.Integrations;
using Person_UI.Model;
namespace Person_UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Person> PersonsList = new List<Person>();
        public string Message { get; private set; } = "Page models in C#";
        private readonly IPersonApiClient _personApiClient;

        public IndexModel(ILogger<IndexModel> logger, IPersonApiClient personApiClient)
        {
            _logger = logger;
            _personApiClient = personApiClient;
        }

        public async Task OnGet()
        {
            try
            {
                Message = $"Server Time : {DateTime.Now}";
                var response = await _personApiClient.GetAllPersons();
                _logger.LogInformation($"api response  GetAllPersons count : { response.Count}");
                PersonsList = response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error onGet : {ex} ");
            }

            //var p = new Person() { FirstName = "FirstName", LastName = "LastName", Address = "Address", DateofBirth = DateTime.Now, Email = "Email@someemail.com", PhoneNumber = "440-252-9887" };
            //var p1 = new Person() { FirstName = "FirstName", LastName = "LastName", Address = "Address", DateofBirth = DateTime.Now, Email = "Email@someemail.com", PhoneNumber = "440-252-9887" };

            //PersonsList = new List<Person>();
            //PersonsList.Add(p);
            //PersonsList.Add(p1);
        }

    }
}