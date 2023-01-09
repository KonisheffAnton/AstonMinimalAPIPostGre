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
        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonCreateDto personCreate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var FilmList = await _context.DbSetOfFilms.AsQueryable().Where(DbSetOfFilmsItem => personCreate.FilmIds.Contains(DbSetOfFilmsItem.FilmId)).ToListAsync();
            var vehicle = await _context.DbSetOfVehicles.AsQueryable().FirstOrDefaultAsync(DbSetOfVehiclesItem => DbSetOfVehiclesItem.VehicleId == personCreate.vehicle.VehicleId);
            var NewPerson = new Person(personCreate.ItemId, personCreate.Name, personCreate.Homeworld, FilmList, vehicle, personCreate.Url);
            _context.DbSetOfPersons.Add(NewPerson);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePersonById([FromRoute] int personId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var personDelete = await _context.DbSetOfPersons.AsQueryable().Include(personItem => personItem.vehicle).Include(personItem => personItem.Films).FirstOrDefaultAsync(personItem => personItem.ItemId == personId);
            _context.DbSetOfPersons.Remove(personDelete);
            await _context.SaveChangesAsync();
            return Ok(personDelete);
        }

        //[HttpPut("{personId}")]
        //public async Task<IActionResult> EditPerson(int personId, PersonDto personToUppdate)
        //{

        //  //  var personToUpdate = await _context.DbSetOfPersons.AsQueryable();

        //    try
        //    {
        //        _context.Update(personToUppdate);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {

        //    }
        //    return Ok(personToUpdate);
        //}

    }
}
