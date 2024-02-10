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
        //public int AssemblyId { get; set; }
        public int AssemblyUnitId { get; set; }
        //public AssemblyUnit AssemblyUnit { get; set; }
        public int DetailId { get; set; }
        //public AssemblyUnit Detail {get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return ($"{nameof(Id)}:{Id} {nameof(Count)}:{Count}");
        }
    }
}
