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
        public JsonResult GetPersons(int id)
        {
            var result = _dbcontext.Persons.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }

        //https://www.youtube.com/watch?v=Tj3qsKSNvMk&list=RDCMUCGjv_3tbzJ8yKuvacoqmO-Q&start_radio=1&rv=Tj3qsKSNvMk&t=383

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
