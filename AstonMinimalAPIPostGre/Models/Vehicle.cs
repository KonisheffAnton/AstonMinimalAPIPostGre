using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Pilots { get; set; }
    }
}
