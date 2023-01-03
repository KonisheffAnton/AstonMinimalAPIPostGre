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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Person>().ToTable("Person");

           // modelBuilder.Entity<Person>().HasData(new Person { ItemId = 1, Name = "Tom", Homeworld = "BubaF", Films = {1}, vehicle = "1", Url = "123123" });
    }
    }
}

