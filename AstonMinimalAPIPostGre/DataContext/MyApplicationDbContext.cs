using AstonMinimalAPIPostGre.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AstonMinimalAPIPostGre
{

    public class MyApplicationDbContext : DbContext
    {

        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Film> DbSetOfFilms { get; set; }
        public DbSet<Vehicle> DbSetOfVehicles { get; set; }
        public DbSet<Person> DbSetOfPersons { get; set; }

    }
}

