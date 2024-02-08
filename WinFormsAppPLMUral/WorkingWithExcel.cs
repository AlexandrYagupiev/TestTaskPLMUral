using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPLMUral.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormsAppPLMUral
{
    internal class WorkingWithExcel
    {
        public void UploadToExcel(DataGridView dataGridViewAssemblyUnits)
        {
            try
            {
                Excel.Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
                if(dataGridViewAssemblyUnits.RowCount>1)
                {
                for (int i = 0; i < dataGridViewAssemblyUnits.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewAssemblyUnits.ColumnCount; j++)
                    {
                        wsh.Cells[i + 1, j + 1] = dataGridViewAssemblyUnits[j, i].Value.ToString();
                    }
                }
                }
                else if(dataGridViewAssemblyUnits.RowCount==1) 
                {
                    for (int i = 0; i < dataGridViewAssemblyUnits.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridViewAssemblyUnits.ColumnCount; j++)
                        {
                            wsh.Cells[i + 1, j + 1] = dataGridViewAssemblyUnits[j, i].Value.ToString();
                        }
                    }
                }
                
                exApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        public void UploadFromExcel(DataGridView dataGridViewAssemblyUnits , ApplicationContext applicationContext)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                AssemblyUnits assemblyUnits = new AssemblyUnits();
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    var resultExcel = excelReader.AsDataSet();
                    excelReader.Close();
                    var dataTable = resultExcel.Tables[0];
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            var nameOfDetail = applicationContext.assemblyUnits
                            .Where(c => c.Name == dataTable.Rows[i][dataTable.Columns[1]].ToString())
                            .FirstOrDefault();
                            if (nameOfDetail != null)
                            {
                                if (j == 2)
                                {
                                    nameOfDetail.Quantity += Convert.ToInt32(dataTable.Rows[i][dataTable.Columns[j]]);
                                    applicationContext.SaveChanges();
                                }
                            }
                            else if (nameOfDetail == null)
                            {
                                if (j == 1)
                                {
                                    assemblyUnits.Name = dataTable.Rows[i][dataTable.Columns[j]].ToString();
                                }
                                if (j == 2)
                                {
                                    assemblyUnits.Quantity = Convert.ToInt32(dataTable.Rows[i][dataTable.Columns[j]]);
                                    applicationContext.assemblyUnits.Add(assemblyUnits);
                                    applicationContext.SaveChanges();
                                }
                            }
                            dataGridViewAssemblyUnits.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }
    }
}
