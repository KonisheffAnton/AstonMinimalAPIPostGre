using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class PersonCreateDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Homeworld { get; set; }
        public ICollection<int> FilmIds { get; set; }
        public VehicleDto vehicle { get; set; }
        public string Url { get; set; }
    }
}
