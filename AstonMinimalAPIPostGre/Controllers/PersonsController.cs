using AstonMinimalAPIPostGre.Dtos;
using AstonMinimalAPIPostGre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<IActionResult> CreatePerson(Person personCreate)
        {
          
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.DbSetOfPersons.Add(personCreate);
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

        //[HttpPost]       
        //public async Task<IActionResult> EditPerson(int? personId)
        //{
        //    if (personId == null)
        //    {
        //        return NotFound();
        //    }

        //    var personToUpdate = await _context.DbSetOfPersons.AsQueryable().FirstOrDefaultAsync(personItem => personItem.ItemId == personId);
            
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException  )
        //        {
                   
        //        }
        //    return Ok(personToUpdate);
        //}

    }
}
