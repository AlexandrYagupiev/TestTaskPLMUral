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
        public int AssemblyUnitId { get; set; }
        public int DetailId { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return ($"{nameof(Id)}:{Id} {nameof(AssemblyUnitId)}:{AssemblyUnitId} {nameof(DetailId)}:{DetailId} {nameof(Count)}:{Count}");
        }
    }
}
