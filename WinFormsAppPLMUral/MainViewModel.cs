using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPLMUral.Models;
using Microsoft.EntityFrameworkCore;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsAppPLMUral
{
    public class MainViewModel
    {
        public List<AssemblyUnit> GetAllAssemblyUnits()
        {
            using (var applicationContext = new ApplicationContext())
            {
                return applicationContext.AssemblyUnits.Include(t => t.Details).ToList();
            }
        }

        public int CreateAssembly(string name, List<RelationAseemblyToAssembly> children)
        {
            using (var applicationContext = new ApplicationContext())
            {
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        if (applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == child.DetailId) == null)
                        {
                            throw new Exception($"{child.Id} нет в базе");
                        }
                        if(children.Where(t=>t.Id==child.Id).Count()>1)
                        {
                            throw new Exception($"Деталь с id:{child.Id} продублированна в составе исходной детали");
                        }

                    }
                }
                if (name == null)
                {
                    throw new Exception("Имя должно быть заполнено");
                }
                var assemblyUnit = new AssemblyUnit();
                assemblyUnit.Name = name;
                if (children != null)
                {
                    assemblyUnit.Details = children;
                }
                applicationContext.AssemblyUnits.Add(assemblyUnit);
                applicationContext.SaveChanges();
                return assemblyUnit.Id;
            }

        }

        public AssemblyUnit GetAssemblyUnitById(int id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                var assemblyUnit = applicationContext.AssemblyUnits.Include(t => t.Details).SingleOrDefault(t => t.Id == id);
                if (assemblyUnit == null)
                {
                    throw new Exception($"Деталь с таким id:{id} отсутсвует");
                }
                return assemblyUnit;
            }
        }

        public void UpdateAssembly(AssemblyUnit assemblyUnit)
        {
            using (var applicationContext = new ApplicationContext())
            {
                var assemblyUnitFromDb = applicationContext.AssemblyUnits.Include(t => t.Details).FirstOrDefault(t => t.Id == assemblyUnit.Id);
                if (assemblyUnitFromDb == null)
                {
                    throw new Exception($"В базе данных нет записи с id:{assemblyUnitFromDb.Id}");
                }
                if (assemblyUnit.Details != null)
                {
                    foreach (var detail in assemblyUnit.Details)
                    {
                        if (applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == detail.DetailId) == null)
                        {
                            throw new Exception($"{detail.DetailId} нет в базе");
                        }
                        if (assemblyUnit.Details.Where(t => t.Id == detail.DetailId).Count() > 1)
                        {
                            throw new Exception($"Деталь с id:{detail.Id} продублированна в составе исходной детали");
                        }
                    }
                }
                var stack = new Stack<AssemblyUnit>();
                stack.Push(assemblyUnit);
                while (stack.Count > 0)
                {
                    var item = stack.Pop();
                    foreach (var detail in item.Details)
                    {
                        var detailFromDb = applicationContext.AssemblyUnits.Include(t => t.Details).FirstOrDefault(t => t.Id == detail.DetailId);
                        if (detailFromDb == null)
                        {
                            throw new Exception($"{detail.DetailId} нет в базе");
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
                //foreach (var detail in assemblyUnit.Details)
                //{
                //    var detailFromDb = applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == detail.AssemblyUnit.Id);
                //    detail.AssemblyUnit = detailFromDb;
                //}
                var detailsToDelete = new List<RelationAseemblyToAssembly>();
                foreach (var detail in assemblyUnitFromDb.Details)
                {
                    var updateDetail = assemblyUnit.Details.FirstOrDefault(d => d.Id == detail.Id);
                    if (updateDetail == null)
                    {
                        detailsToDelete.Add(detail);
                    }
                    else
                    {
                        detail.Count = updateDetail.Count;
                    }
                }
                foreach (var detailToDelete in detailsToDelete)
                {
                    assemblyUnitFromDb.Details.Remove(detailToDelete);
                }
                foreach (var detail in assemblyUnit.Details)
                {
                    if (detail.Id==0)
                    {                       
                        detail.AssemblyUnitId = assemblyUnit.Id;
                        assemblyUnitFromDb.Details.Add(detail);
                    }
                }
                applicationContext.SaveChanges();
            }
        }

        public void DeleteAssembly(int id)
        {
            using (var applicationContext = new ApplicationContext())
            {
                var assemblyUnitFromDb = applicationContext.AssemblyUnits.FirstOrDefault(t => t.Id == id);
                if (assemblyUnitFromDb == null)
                {
                    throw new Exception($"В базе данных нет записи с id:{assemblyUnitFromDb.Id}");
                }
                foreach (var assemblyUnit in applicationContext.AssemblyUnits.Include(t => t.Details))
                {
                    foreach (var detail in assemblyUnit.Details)
                    {
                        if (detail.DetailId == id)
                        {
                            throw new Exception($"Деталь с id:{id} вложена в другу деталь c id:{assemblyUnit.Id}");
                        }
                    }
                }
                applicationContext.Relations.RemoveRange(assemblyUnitFromDb.Details);
                applicationContext.AssemblyUnits.Remove(assemblyUnitFromDb);
                applicationContext.SaveChanges();
            }

        }

        public void Export(string path)
        {
            using (var applicationContext = new ApplicationContext())
            { 
                var excelApp = new Excel.Application();
                var workBook = excelApp.Workbooks.Add();
                try
                {
                   
                    var wsh = (Excel.Worksheet)workBook.ActiveSheet;
                    var rowNumber = 1;
                    foreach (var assemblyUnit in applicationContext.AssemblyUnits)
                    {
                        wsh.Cells[rowNumber, 1] = assemblyUnit.Id.ToString();
                        wsh.Cells[rowNumber, 2] = assemblyUnit.Name;
                        rowNumber++;
                    }
                    var wsh2 = workBook.Sheets.Add();
                    //var wsh2 = (Excel.Worksheet)workBook.ActiveSheet;
                    rowNumber = 1;
                    foreach (var relation in applicationContext.Relations)
                    {
                        wsh2.Cells[rowNumber, 1] = relation.AssemblyUnitId;
                        wsh2.Cells[rowNumber, 2] = relation.Count;
                        wsh2.Cells[rowNumber, 3] = relation.Id;
                        wsh2.Cells[rowNumber, 4] = relation.DetailId;
                        rowNumber++;
                    }
                    var pathSplit =Path.GetDirectoryName(path)+"\\"+Path.GetFileNameWithoutExtension(path);                 
                    workBook.SaveAs(pathSplit, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, AccessMode: Excel.XlSaveAsAccessMode.xlExclusive);
                }
                finally 
                {
                    workBook.Close();
                    excelApp.Quit();
                }
            }
        }
        public string GetCellValue(Excel.Worksheet worksheet, int i, int j)
        {
            return ((object)((Excel.Range)worksheet.Cells[i, j]).Value).ToString();
        }

        public void Import(string path)
        {
            using (var applicationContext = new ApplicationContext())
            {
                applicationContext.AssemblyUnits.RemoveRange(applicationContext.AssemblyUnits);
                applicationContext.Relations.RemoveRange(applicationContext.Relations);
                applicationContext.SaveChanges();
                var excelApp = new Excel.Application();
                var workbook = excelApp.Workbooks.Open(path);
                try
                {                  
                    var wsh = (Excel.Worksheet)workbook.Sheets[2];
                    for (int i = 1; i < wsh.UsedRange.Rows.Count + 1; i++)
                    {
                        var assemblyUnit = new AssemblyUnit();
                        assemblyUnit.Id = int.Parse(GetCellValue(wsh, i, 1));
                        assemblyUnit.Name = GetCellValue(wsh, i, 2);
                        applicationContext.AssemblyUnits.Add(assemblyUnit);
                        applicationContext.SaveChanges();
                    }
                    var wsh2 = (Excel.Worksheet)workbook.Sheets[1];
                    for (int i = 1; i < wsh2.UsedRange.Rows.Count + 1; i++)
                    {
                        var relationAseemblyToAssembly = new RelationAseemblyToAssembly();
                        relationAseemblyToAssembly.AssemblyUnitId = int.Parse(GetCellValue(wsh2, i, 1));
                        relationAseemblyToAssembly.Count = int.Parse(GetCellValue(wsh2, i, 2));
                        relationAseemblyToAssembly.Id = int.Parse(GetCellValue(wsh2, i, 3));
                        relationAseemblyToAssembly.DetailId = int.Parse(GetCellValue(wsh2, i, 4));
                        applicationContext.Relations.Add(relationAseemblyToAssembly);
                        applicationContext.SaveChanges();
                    }
                }
                finally
                {
                    workbook.Close();
                    excelApp.Quit();
                }

            }
        }
    }
}
