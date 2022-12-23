using AstonMinimalAPIPostGre.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public ItemsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]  
        public IEnumerable<Person> Get()
        {
            return _dataAccessProvider.GetPatientRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                item.ItemId = obj.ToString();
                _dataAccessProvider.AddItemRecord(item);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Person Details(string id)
        {
            return _dataAccessProvider.GetItemSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Person item)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateItemtRecord(item);
                return Ok();
            }
            return BadRequest();
        }

       
    }
}
