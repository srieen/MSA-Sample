using Microsoft.AspNetCore.Mvc;
using Person_API.Interfaces;
using Person_API.Model;
using System.Text.Json;

namespace Person_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IProcessPersonLogic _processPerson;

        public ILogger<PersonController> _logger { get; }

        public PersonController(ILogger<PersonController> logger, IPersonRepository  personRepository, IProcessPersonLogic processPerson)
        {
            _logger = logger;
            _personRepository = personRepository;
            _processPerson = processPerson;
        }


        [HttpGet]
        public async Task<ActionResult<Person>> GetAllPersons(CancellationToken cancellationToken)
        {
            string correlationId = Guid.NewGuid().ToString();   
            try
            {
                var persons = await _processPerson.GetAllPersons(correlationId,cancellationToken);

                _logger.LogInformation($"Get All person response : {JsonSerializer.Serialize(persons)}");

                return Ok(persons);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error on GetAllPersons : {ex} CorrelationId : {correlationId}");                
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddPerson(Person newPerson, CancellationToken cancellationToken)
        {
            string correlationId = Guid.NewGuid().ToString();

            try
            {
                string gId = Guid.NewGuid().ToString();

                newPerson.Id = gId.ToString();
                var result = await _processPerson.AddPerson(newPerson, correlationId, cancellationToken);

                _logger.LogInformation($"Add New person response : {gId}");

                return Ok(gId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error on AddPerson : {ex} CorrelationId : {correlationId}");
                return StatusCode(500, ex.Message);
            }                       
        }


    }
}
