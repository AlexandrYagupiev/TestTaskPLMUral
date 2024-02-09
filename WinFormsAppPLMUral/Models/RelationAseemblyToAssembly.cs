using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPLMUral.Models
{
    public class RelationAseemblyToAssembly
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public AssemblyUnit Detail { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return ($"{Id} {Detail} {Count}");
        }
    }
}
