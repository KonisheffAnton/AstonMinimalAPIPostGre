using AstonMinimalAPIPostGre.Models;
using System.Collections.Generic;

namespace AstonMinimalAPIPostGre.Dtos
{
    public class FilmDto
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public ICollection<string> PersonNamesInFilms { get; set; }
        public ICollection<string> VehiclesNamesInFilms { get; set; }
        public string Url { get; set; }
    }
}
