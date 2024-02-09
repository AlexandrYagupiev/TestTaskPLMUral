using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinFormsAppPLMUral.Models;

namespace WinFormsAppPLMUral
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<AssemblyUnit> AssemblyUnits { get; set; }
        public DbSet<RelationAseemblyToAssembly> Relations { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=file:WinFormsAppPLMUralDB.db");
        }
    }
}
