using System.Collections.Generic;
using System.Security.Policy;
using System.Xml.Linq;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class PersonCreateDto
    {
       

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Homeworld { get; set; }
        public ICollection<int> FilmIds { get; set; }
        public int vehicleId { get; set; }
        public string Url { get; set; }

        public PersonCreateDto(int itemId, string name, string homeworld, ICollection<int> filmIds, int vehicleId, string url)
        {
            ItemId = itemId;
            Name = name;
            Homeworld = homeworld;
            FilmIds = filmIds;
            this.vehicleId = vehicleId;
            Url = url;
        }

        public PersonCreateDto()
        {
        }
    }
   

}
