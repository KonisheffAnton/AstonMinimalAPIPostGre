using AstonMinimalAPIPostGre.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AstonMinimalAPIPostGre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        MyApplicationDbContext _context;

        public PersonsController(MyApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> GetPersonById([FromRoute] int personId)
        {
            var person = await _context.DbSetOfPersons.AsQueryable().Where(c => c.ItemId == personId).Include(c=>c.vehicle).FirstOrDefaultAsync();
            
            if (person != null)
            {
                return person;
            }
            else
            {
                return NotFound();
            }

        }
        //[HttpGet]
        //public Task GetPersonList()
        //{

        //}
        //[HttpPost]
        //public Task CreatePerson([FromBody] int personId)
        //{

        //}
        //[HttpDelete]
        //public Task DeletePersonById([FromRoute] int personId)
        //{

        //}

    }
}
