using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPLMUral.Models
{
    public class AssemblyUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RelationAseemblyToAssembly> Details { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
