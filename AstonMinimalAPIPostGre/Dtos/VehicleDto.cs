using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public ICollection<string> PilotsInVehicle { get; set; }
    }
}
