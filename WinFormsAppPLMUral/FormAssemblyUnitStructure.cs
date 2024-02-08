using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Office.Interop.Excel;
using WinFormsAppPLMUral.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppPLMUral
{
    public partial class FormAssemblyUnitStructure : Form
    {
        ApplicationContext applicationContext;
        WorkingWithExcel withExcel = new WorkingWithExcel();
        public FormAssemblyUnitStructure()
        {
            InitializeComponent();
        }

        private void LoadDataGridViewAssemblyUnits()
        {
            try
            {
                applicationContext = new ApplicationContext();
                applicationContext.assemblyUnits.Load();
                dataGridViewAssemblyUnits.DataSource = applicationContext.assemblyUnits.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        private void FormAssemblyUnitStructure_Load(object sender, EventArgs e)
        {
            LoadDataGridViewAssemblyUnits();
            LoadComboBoxSortName();
        }

        private void LoadComboBoxSortName()
        {
            try
            {
                comboBoxSortName.DataSource = applicationContext.assemblyUnits.Local.Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        private void buttonUploadToExcel_Click(object sender, EventArgs e)
        {
            withExcel.UploadToExcel(dataGridViewAssemblyUnits);
        }

        private void buttonLoadingFromExcel_Click(object sender, EventArgs e)
        {
            withExcel.UploadFromExcel(dataGridViewAssemblyUnits, applicationContext);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAssemblyUnits.SelectedRows.Count > 0)
                {
                    int index = dataGridViewAssemblyUnits.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridViewAssemblyUnits[0, index].Value.ToString(), out id);
                    if (converted == false)
                    {
                        return;
                    }
                    AssemblyUnits assemblyUnits = applicationContext.assemblyUnits.Find(id);
                    applicationContext.assemblyUnits.Remove(assemblyUnits);
                    applicationContext.SaveChanges();
                    MessageBox.Show("Запись успешно удалена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAssemblyUnits.SelectedRows.Count > 0)
                {
                    int index = dataGridViewAssemblyUnits.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridViewAssemblyUnits[0, index].Value.ToString(), out id);
                    if (converted == false)
                    {
                        return;
                    }
                    AssemblyUnits assemblyUnits = applicationContext.assemblyUnits.Find(id);
                    FormEditingAndAddingDetails formEditingAndAddingDetails = new FormEditingAndAddingDetails();

                    formEditingAndAddingDetails.textBoxName.Text = assemblyUnits.Name;
                    formEditingAndAddingDetails.textBoxQuantity.Text = assemblyUnits.Quantity.ToString();

                    DialogResult result = formEditingAndAddingDetails.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }

                    assemblyUnits.Name = formEditingAndAddingDetails.textBoxName.Text;
                    assemblyUnits.Quantity = Convert.ToInt32(formEditingAndAddingDetails.textBoxQuantity.Text);

                    applicationContext.SaveChanges();
                    dataGridViewAssemblyUnits.Refresh();
                    MessageBox.Show("Запись успешно обновлена");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditingAndAddingDetails formEditingAndAddingDetails = new FormEditingAndAddingDetails();
                DialogResult result = formEditingAndAddingDetails.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                AssemblyUnits assemblyUnits = new AssemblyUnits();

                var nameOfDetail = applicationContext.assemblyUnits
                .Where(c => c.Name == formEditingAndAddingDetails.textBoxName.Text)
                .FirstOrDefault();
                if (nameOfDetail != null)
                {
                    nameOfDetail.Quantity += Convert.ToInt32(formEditingAndAddingDetails.textBoxQuantity.Text);
                    applicationContext.SaveChanges();
                    dataGridViewAssemblyUnits.Refresh();
                    MessageBox.Show("Запись успешно обновлена");

                }
                else if (nameOfDetail == null)
                {
                    assemblyUnits.Name = formEditingAndAddingDetails.textBoxName.Text;
                    assemblyUnits.Quantity = Convert.ToInt32(formEditingAndAddingDetails.textBoxQuantity.Text);
                    applicationContext.assemblyUnits.Add(assemblyUnits);
                    applicationContext.SaveChanges();
                    dataGridViewAssemblyUnits.Refresh();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex);
            }
        }

        private void comboBoxSortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterActivity.Checked)
            {
                dataGridViewAssemblyUnits.DataSource = applicationContext.assemblyUnits.Where(t => t.Name == comboBoxSortName.Text).ToList();
            }
        }

        private void checkBoxFilterActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterActivity.Checked)
            {
                dataGridViewAssemblyUnits.DataSource = applicationContext.assemblyUnits.Where(t => t.Name == comboBoxSortName.Text).ToList();
            }
            else if (!checkBoxFilterActivity.Checked)
            {
                LoadDataGridViewAssemblyUnits();
            }
        }
    }
}
