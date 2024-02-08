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
        public DbSet<AssemblyUnits> assemblyUnits { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB\LocalDBWinFormsAppPLMUral.mdf;Integrated Security=True");
        }
    }
}
