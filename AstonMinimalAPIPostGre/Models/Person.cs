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

        public Person(int itemId, string name, string homeworld, ICollection<Film> films, Vehicle vehicle, string url)
        {
            ItemId = itemId;
            Name = name;
            Homeworld = homeworld;
            Films = films;
            this.vehicle = vehicle;
            Url = url;
        }

        private Person()
        {
        }


        //public Person (int ItemId, string Name, string Homeworld, ICollection<Film> film, Vehicle vehicle, string url) {



        //}

    }
}