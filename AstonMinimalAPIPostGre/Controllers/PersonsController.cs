using AstonMinimalAPIPostGre.Dtos;
using AstonMinimalAPIPostGre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<ActionResult<PersonDto>> GetPersonById([FromRoute] int personId)
        {
            var person = await _context.DbSetOfPersons.AsQueryable().Include(personItem => personItem.vehicle).Include(personItem => personItem.Films).Select(personItem =>
                new PersonDto()
                {
                    ItemId = personItem.ItemId,
                    Name = personItem.Name,
                    Homeworld = personItem.Homeworld,
                    FilmNameWithPerson = personItem.Films.Select(film => film.Name).ToList(),
                    vehicle = personItem.vehicle.Name
                }).SingleOrDefaultAsync(c => c.ItemId == personId);

            //select * from persons inner join  Vehicle on person.vehicleid = vehicleid inner join on person where pesonId = personId 

            if (person != null)
            {
                return person;
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        public async Task<ActionResult<ICollection<PersonDto>>> GetPersonList()
        {
            var personList = await _context.DbSetOfPersons.AsQueryable().Include(personItem => personItem.vehicle).Include(personItem => personItem.Films).Select(personItem =>
                new PersonDto()
                {
                    ItemId = personItem.ItemId,
                    Name = personItem.Name,
                    Homeworld = personItem.Homeworld,
                    FilmNameWithPerson = personItem.Films.Select(film => film.Name).ToList(),
                    vehicle = personItem.vehicle.Name
                }).ToListAsync();

            //select * from persons inner join  Vehicle on person.vehicleid = vehicleid inner join on person where pesonId = personId 

            if (personList != null)
            {
                return personList;
            }
            else
            {
                return NotFound();
            }

        }
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
