using Person_UI.Model;

namespace Person_UI.Integrations
{
    public class PersonApiClient : IPersonApiClient
    {
        private readonly HttpClient _client;

        public PersonApiClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _client.BaseAddress = new Uri(config.GetValue<string>("PersonApiUrl"));
        }

        public async Task<bool> AddPerson(Person person)
        {
            bool success = false;   
            var response = await _client.PostAsJsonAsync("api/person", person);

            if (response.IsSuccessStatusCode)
            {
                success =  await response.Content.ReadFromJsonAsync<bool>();
            }
            return success; 
        }

        public async Task<List<Person>> GetAllPersons()
        {
           return await _client.GetFromJsonAsync<List<Person>>("api/person");
        }
    }
}
