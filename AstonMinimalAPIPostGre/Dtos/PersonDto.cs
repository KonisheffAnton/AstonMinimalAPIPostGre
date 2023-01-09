using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class PersonDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Homeworld { get; set; }
        public ICollection<string> FilmNameWithPerson { get; set; }
        public string vehicle { get; set; }
    }
}
