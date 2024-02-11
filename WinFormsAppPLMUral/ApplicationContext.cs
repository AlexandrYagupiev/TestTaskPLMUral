using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinFormsAppPLMUral.Models;

namespace WinFormsAppPLMUral
{
    public class ApplicationContext : DbContext
    {
        private readonly bool debug;

        public DbSet<AssemblyUnit> AssemblyUnits { get; set; }
        public DbSet<RelationAseemblyToAssembly> Relations { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(bool debug)
        {
            if (debug)
            {
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
            this.debug = debug;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(debug)
            {
               optionsBuilder.EnableSensitiveDataLogging(true);
            }
            optionsBuilder.UseSqlite(@"Data Source=file:WinFormsAppPLMUralDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssemblyUnit>().HasMany<RelationAseemblyToAssembly>().WithOne().HasForeignKey(t=>t.AssemblyUnitId).HasForeignKey(t => t.DetailId);
            modelBuilder.Entity<AssemblyUnit>().Navigation(t => t.Details).UsePropertyAccessMode(propertyAccessMode:PropertyAccessMode.Property);
        }
    }
}
