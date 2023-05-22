using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPV_REST.Models;

namespace SPV_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _dbcontext;

        public PersonController(PersonContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        //Get: api/Person
        [HttpGet]
        public IActionResult GetPersons(int id)
        {
            var persons = _dbcontext.Persons.ToList();
            if (persons.Count == 0)
            {
                return NotFound();
            }
            return Ok(persons);
        }

        // GET: api/Person/id
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _dbcontext.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        
        //Post: api/Person
        [HttpPost]
        public JsonResult PostPersons(Person person)
        {
            if (person.Id == null)
            {
                _dbcontext.Persons.Add(person);
            }
            else
            {
                var PersonId = _dbcontext.Persons.Find(person.Id);
                if (PersonId == null) { 
                    return new JsonResult(NotFound());
            }
                PersonId = person; //ersätter den nuvarande id mot den nya 

            }
            _dbcontext.SaveChanges();
            return new JsonResult(Ok(person));

        }

        //Delete: api/Person
        
        [HttpDelete]
        public JsonResult DeletePerson(int id)
        {
            var result = _dbcontext.Persons.Find(id);
            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            _dbcontext.Persons.Remove(result);
            _dbcontext.SaveChanges();
            return new JsonResult(NoContent());
        }
    }

}
