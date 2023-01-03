using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AstonMinimalAPIPostGre.Models
{
    public class Person
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Homeworld { get; set; }
        public ICollection<Film> Films { get; set; }
        public Vehicle vehicle { get; set; }
        public string Url { get; set; }

    }
}