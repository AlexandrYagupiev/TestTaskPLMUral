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
        private readonly MainViewModel mainViewModel;

        public FormAssemblyUnitStructure(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.mainViewModel = mainViewModel;
            Show();
        }

        public void Show()
        {
            listViewAssemblyUnits.Items.Clear();
            var units = mainViewModel.GetAllAssemblyUnits();
            foreach (var unit in units)
            {
                listViewAssemblyUnits.Items.Add(new ListViewItem(unit.Name)
                {
                    Tag = unit.Id
                });
                //listViewAssemblyUnits.Items.Add($"{unit.Id} {unit.Name}");
            }
        }



        private void FormAssemblyUnitStructure_Load(object sender, EventArgs e)
        {
        }



        private void buttonUploadToExcel_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadingFromExcel_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (listViewAssemblyUnits.SelectedItems.Count>0)
            {
                var assemblyUnit = mainViewModel.GetAssemblyUnitById((int)listViewAssemblyUnits.SelectedItems[0].Tag);
                using (FormEditingAndAddingDetails form = new FormEditingAndAddingDetails(assemblyUnit, mainViewModel.GetAllAssemblyUnits()))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        this.mainViewModel.UpdateAssembly(assemblyUnit);
                        Show();
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyUnit assemblyUnit = new AssemblyUnit();
                using (FormEditingAndAddingDetails form = new FormEditingAndAddingDetails(assemblyUnit, mainViewModel.GetAllAssemblyUnits()))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        mainViewModel.CreateAssembly(assemblyUnit.Name, assemblyUnit.Details);
                        Show();
                    }

                    //form.
                    //mainViewModel.CreateAssembly();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }

        }

        private void comboBoxSortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxFilterActivity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormAssemblyUnitStructure_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
