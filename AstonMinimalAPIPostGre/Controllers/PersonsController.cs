using AstonMinimalAPIPostGre.Dtos;
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
            var person = await _context.DbSetOfPersons.AsQueryable().Include(b => b.Films).Select(c => new PersonDto()
            {
                ItemId = c.ItemId,

                Name = c.Name,

                Vehicle = c.vehicle.Name,

                
                
                Url = c.Url 
    }
        ).SingleOrDefaultAsync(b => b.ItemId == personId);




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
