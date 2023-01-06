using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class PersonDto
    {

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Vehicle { get; set; }
        public List<string> FilmName { get; set; } = new List<string>();
        public string Url { get; set; }

    }
}
