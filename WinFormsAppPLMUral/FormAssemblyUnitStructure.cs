using System.Numerics;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using WinFormsAppPLMUral.Models;

namespace WinFormsAppPLMUral
{
    public partial class FormAssemblyUnitStructure : Form
    {
        ApplicationContext applicationContext;
        public FormAssemblyUnitStructure()
        {
            InitializeComponent();
        }

        private void LoadDataGridViewAssemblyUnits()
        {
            applicationContext = new ApplicationContext();
            applicationContext.assemblyUnits.Load();
            dataGridViewAssemblyUnits.DataSource = applicationContext.assemblyUnits.Local.ToBindingList();
        }

        private void FormAssemblyUnitStructure_Load(object sender, EventArgs e)
        {
            LoadDataGridViewAssemblyUnits();
        }

        private void buttonUploadToExcel_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadingFromExcel_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
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

        private void buttonChange_Click(object sender, EventArgs e)
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

        private void buttonAdd_Click(object sender, EventArgs e)
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
                MessageBox.Show("Запись успешно обновлена");
                LoadDataGridViewAssemblyUnits();
            }
            else if (nameOfDetail == null)
            {
                assemblyUnits.Name = formEditingAndAddingDetails.textBoxName.Text;
                assemblyUnits.Quantity = Convert.ToInt32(formEditingAndAddingDetails.textBoxQuantity.Text);
                applicationContext.assemblyUnits.Add(assemblyUnits);
                applicationContext.SaveChanges();
                MessageBox.Show("Запись успешно добавлена");
            }

        }
    }
}
