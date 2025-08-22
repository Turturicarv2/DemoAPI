using DemoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using DemoServiceReference;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    /// <summary>
    /// Basic Controller for People
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private DemoServiceClient _demoServiceClient = new DemoServiceClient();

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns>a list of persons</returns>
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IResult> GetPersons()
        {
            var result = await _personService.GetAllPersonsAsync();
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }

        /// <summary>
        /// Get a specific person
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns>person that matches the unique identifier (id)</returns>
        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetPersonById(int id)
        {
            var result = await _personService.GetPersonByIdAsync(id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }

        /// <summary>
        /// Get all people's first names
        /// </summary>
        /// <returns>list of strings</returns>
        //// GET api/<PersonController>/GetFirstNames
        [HttpGet]
        public async Task<IResult> GetFirstNames()
        {
            var result = await _personService.GetFirstNamesAsync();
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }

        /// <summary>
        /// Add a person to the list of persons
        /// </summary>
        /// <param name="FirstName">first name of person</param>
        /// <param name="LastName">last name of person</param>
        // POST api/<PersonController>
        [HttpPost]
        public async Task<IResult> PostPerson(string FirstName, string LastName)
        {
            await _personService.AddPersonAsync(FirstName, LastName);
            return Results.Ok();
        }

        /// <summary>
        /// Update a person from the list of persons
        /// </summary>
        /// <param name="updatedPerson">person's updated info</param>
        // POST api/<PersonController>
        [HttpPut]
        public async Task<IResult> UpdatePerson(PersonModel updatedPerson)
        {
            await _personService.UpdatePersonAsync(updatedPerson);
            return Results.Ok();
        }

        /// <summary>
        /// Delete a person from the list of people
        /// </summary>
        /// <param name="id">unique identifier</param>
        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeletePerson(int id)
        {
            await _personService.DeletePersonAsync(id);
            return Results.Ok();
        }

        [HttpGet]
        public IActionResult GetNamesFromWcfService()
        {
            return Ok(_demoServiceClient.HelloAsync().Result);
        }
    }
}
