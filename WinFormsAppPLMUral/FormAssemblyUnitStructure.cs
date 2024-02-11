using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.Design;
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
            try
            {
                treeViewAssemblyUnits.Nodes.Clear();
                listViewAssemblyUnits.Items.Clear();
                var units = mainViewModel.GetAllAssemblyUnits();
                foreach (var unit in units)
                {
                    listViewAssemblyUnits.Items.Add(new ListViewItem(unit.Name)
                    {
                        Tag = unit.Id
                    });
                }

                foreach (var unit in units)
                {
                    var stack = new Stack<(AssemblyUnit unit, TreeNode node)>();
                    var rootNode = new TreeNode(unit.Name);
                    treeViewAssemblyUnits.Nodes.Add(rootNode);
                    stack.Push((unit, rootNode));
                    while (stack.Count > 0)
                    {
                        var item = stack.Pop();
                        if (item.unit.Details != null)
                        {
                            foreach (var detail in item.unit.Details)
                            {
                                var childNode = new TreeNode(units.FirstOrDefault(t => t.Id == detail.DetailId).Name);
                                stack.Push((units.FirstOrDefault(t => t.Id == detail.DetailId), childNode));
                                item.node.Nodes.Add(childNode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FormAssemblyUnitStructure_Load(object sender, EventArgs e)
        {
        }



        private void buttonUploadToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        mainViewModel.Export(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoadingFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        mainViewModel.Import(openFileDialog.FileName);
                        Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAssemblyUnits.SelectedItems.Count > 0)
                {
                    mainViewModel.DeleteAssembly((int)listViewAssemblyUnits.SelectedItems[0].Tag);
                    Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAssemblyUnits.SelectedItems.Count > 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Œ¯Ë·Í‡");
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

        private void buttonSortByName_Click(object sender, EventArgs e)
        {
            var items = listViewAssemblyUnits.Items.Cast<ListViewItem>().OrderBy(x => x.Text).ToList();
            listViewAssemblyUnits.Items.Clear();
            listViewAssemblyUnits.Items.AddRange(items.ToArray());
        }
    }
}
