using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPLMUral.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsAppPLMUral
{
    public partial class FormEditingAndAddingDetails : Form
    {
        private readonly AssemblyUnit assemblyUnit;
        private readonly List<AssemblyUnit> assemblyUnits;

        public FormEditingAndAddingDetails(AssemblyUnit assemblyUnit, List<AssemblyUnit> assemblyUnits)
        {
            InitializeComponent();
            this.assemblyUnit = assemblyUnit;
            this.assemblyUnits = assemblyUnits;
        }

        private void SetComboBox(List<AssemblyUnit> assemblyUnits, int index,int defaultId)
        {
            if (assemblyUnits.Count > 0)
            {
                var row = dataGridViewDetailsSelector.Rows[index];
                var comboBox = (DataGridViewComboBoxCell)row.Cells[0];
                //foreach (var item in assemblyUnits)
                //{
                //    comboBox.Items.Add(item.ToString());
                //    comboBox.DataSource = "Test";
                //}
                comboBox.DataSource = assemblyUnits;
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = "Name";
                comboBox.Value = defaultId;
            }

        }

        public void Show()
        {
            textBoxName.Text = assemblyUnit.Name;
            if (assemblyUnit.Details != null)
            {
                foreach (var detail in assemblyUnit.Details)
                {
                    var rowNumber = dataGridViewDetailsSelector.Rows.Add();
                    var row = dataGridViewDetailsSelector.Rows[rowNumber];
                    var textBox = (DataGridViewTextBoxCell)row.Cells[1];
                    textBox.Value = detail.Count;
                    SetComboBox(assemblyUnits, rowNumber,detail.Id);
                }
            }
            //var rowNumber = dataGridViewDetailsSelector.Rows.Add();
            //var row = dataGridViewDetailsSelector.Rows[rowNumber];
            //var comboBox = (DataGridViewComboBoxColumn)row.Cells[0].OwningColumn;
            //var textBox = (DataGridViewTextBoxColumn)row.Cells[1].OwningColumn;

            //row.Cells[0].Value = detail;
        }

        private void FormEditingAndAddingDetails_Shown(object sender, EventArgs e)
        {
            Show();
        }
        private void dataGridViewDetailsSelector_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridViewDetailsSelector_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dataGridViewDetailsSelector_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var rowNumber = dataGridViewDetailsSelector.Rows.Add();
            SetComboBox(assemblyUnits, rowNumber,0);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            assemblyUnit.Name = textBoxName.Text;
            assemblyUnit.Details = new();
            for (int i=0;i< dataGridViewDetailsSelector.RowCount;i++)
            {
                var comboBox = (DataGridViewComboBoxCell)dataGridViewDetailsSelector.Rows[i].Cells[0];
                var textBox = (DataGridViewTextBoxCell)dataGridViewDetailsSelector.Rows[i].Cells[1];
                assemblyUnit.Details.Add(new RelationAseemblyToAssembly()
                {
                    Count = int.Parse(textBox.Value.ToString()),
                    Detail = new AssemblyUnit()
                    {
                        Id= (int)comboBox.Value
                    }
                }
                );
            }
        }
    }
}
