using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AstonMinimalAPIPostGre.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Name { get; set; }
        public  ICollection<Person> Person { get; set; }
        public  ICollection<Vehicle> Vehicles { get; set; }
        public string Url { get; set; }
    }
}
