using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPLMUral.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;

namespace WinFormsAppPLMUral
{
    public class MainViewModel
    {
        public List<AssemblyUnit> GetAllAssemblyUnits()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.AssemblyUnits.ToList();
            }
        }

        public void CreateAssembly(string name, List<RelationAseemblyToAssembly> relations)
        {
            using (var applicationContext = new ApplicationContext())
            {
                if (relations != null)
                {
                    foreach (var relation in relations)
                    {
                        if (applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == relation.Detail.Id) == null)
                        {
                            throw new Exception($"{relation.Detail.Id} нет в базе");
                        }
                    }
                }
                if (name == null)
                {
                    throw new Exception("Имя должно быть заполнено");
                }
                var assemblyUnit = new AssemblyUnit();
                assemblyUnit.Name = name;
                if (relations != null)
                {
                    assemblyUnit.Details = relations;
                }
                applicationContext.AssemblyUnits.Add(assemblyUnit);
                applicationContext.SaveChanges();
            }

        }

        public AssemblyUnit GetAssemblyUnitById(int id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                var assemblyUnit = applicationContext.AssemblyUnits.Include(t => t.Details).SingleOrDefault(t => t.Id == id);
                if (assemblyUnit == null)
                {
                    throw new Exception($"Деталь с таким {id} отсутсвует");
                }
                return assemblyUnit;
            }
        }

        public void UpdateAssembly(AssemblyUnit assemblyUnit)
        {
            using (var applicationContext = new ApplicationContext())
            {
                var assemblyUnitFromDb = applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == assemblyUnit.Id);
                if (assemblyUnitFromDb == null)
                {
                    throw new Exception($"В базе данных нет записи с id:{assemblyUnitFromDb.Id}");
                }
                if (assemblyUnit.Details != null)
                {
                    foreach (var relation in assemblyUnit.Details)
                    {
                        if (applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == relation.Detail.Id) == null)
                        {
                            throw new Exception($"{relation.Detail.Id} нет в базе");
                        }
                    }
                }
                var stack = new Stack<AssemblyUnit>();
                stack.Push(assemblyUnit);
                while (stack.Count > 0)
                {
                    var item = stack.Pop();
                    foreach (var relation in item.Details)
                    {
                        var detailFromDb = applicationContext.AssemblyUnits.Include(t => t.Details).FirstOrDefault(t => t.Id == relation.Detail.Id);
                        if (detailFromDb == null)
                        {
                            throw new Exception($"{relation.Id} нет в базе");
                        }
                        stack.Push(detailFromDb);
                    }
                    if (item == assemblyUnit)
                    {
                        continue;
                    }
                    if (item.Id == assemblyUnit.Id)
                    {
                        throw new Exception($"Возникла закольцованность");
                    }

                }
            }
            using (var applicationContext = new ApplicationContext())
            {
                foreach (var detail in assemblyUnit.Details)
                {
                    applicationContext.Relations.Add(detail);
                    applicationContext.SaveChanges();
                }
                assemblyUnit.Details = applicationContext.Relations.Where(t => t.Detail.Id == assemblyUnit.Id).ToList();
                applicationContext.AssemblyUnits.Update(assemblyUnit);
                applicationContext.SaveChanges();
            }
        }

        public void DeleteAssembly()
        {

        }
    }
}
