using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Person_UI.Integrations;
using Person_UI.Model;

namespace Person_UI.Pages
{
    public class createModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        private readonly ILogger<createModel> _logger;
        private readonly IPersonApiClient _personApiClient;

        public createModel(ILogger<createModel> logger, IPersonApiClient personApiClient)
        {
            _logger = logger;
            _personApiClient = personApiClient;
        }

        public void OnGet()
        {
        
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Person.Id = String.Empty;
                    var result = await _personApiClient.AddPerson(Person);
                    _logger.LogInformation($"api response AddPerson : { result}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error OnPost : {ex} ");
            }

            return RedirectToPage("Index");
        }
    }
}
