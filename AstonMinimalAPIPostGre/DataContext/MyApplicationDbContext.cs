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
        public DbSet<Item> items { get; set; }

    }
}

