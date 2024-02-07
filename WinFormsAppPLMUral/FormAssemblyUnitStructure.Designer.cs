
namespace WinFormsAppPLMUral
{
    partial class FormAssemblyUnitStructure
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewAssemblyUnits = new DataGridView();
            buttonUploadToExcel = new Button();
            buttonLoadingFromExcel = new Button();
            buttonAdd = new Button();
            buttonChange = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssemblyUnits).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAssemblyUnits
            // 
            dataGridViewAssemblyUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAssemblyUnits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssemblyUnits.Location = new Point(12, 12);
            dataGridViewAssemblyUnits.Name = "dataGridViewAssemblyUnits";
            dataGridViewAssemblyUnits.Size = new Size(760, 456);
            dataGridViewAssemblyUnits.TabIndex = 0;
            // 
            // buttonUploadToExcel
            // 
            buttonUploadToExcel.Location = new Point(12, 526);
            buttonUploadToExcel.Name = "buttonUploadToExcel";
            buttonUploadToExcel.Size = new Size(117, 23);
            buttonUploadToExcel.TabIndex = 1;
            buttonUploadToExcel.Text = "Выгрузка в Excel";
            buttonUploadToExcel.UseVisualStyleBackColor = true;
            buttonUploadToExcel.Click += buttonUploadToExcel_Click;
            // 
            // buttonLoadingFromExcel
            // 
            buttonLoadingFromExcel.Location = new Point(135, 526);
            buttonLoadingFromExcel.Name = "buttonLoadingFromExcel";
            buttonLoadingFromExcel.Size = new Size(112, 23);
            buttonLoadingFromExcel.TabIndex = 2;
            buttonLoadingFromExcel.Text = "Загрузка из Excel";
            buttonLoadingFromExcel.UseVisualStyleBackColor = true;
            buttonLoadingFromExcel.Click += buttonLoadingFromExcel_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 474);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(117, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(135, 474);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(117, 23);
            buttonChange.TabIndex = 4;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(258, 474);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(117, 23);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormAssemblyUnitStructure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(buttonDelete);
            Controls.Add(buttonChange);
            Controls.Add(buttonAdd);
            Controls.Add(buttonLoadingFromExcel);
            Controls.Add(buttonUploadToExcel);
            Controls.Add(dataGridViewAssemblyUnits);
            Name = "FormAssemblyUnitStructure";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Структура сборочной единицы";
            Load += FormAssemblyUnitStructure_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssemblyUnits).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dataGridViewAssemblyUnits;
        private Button buttonUploadToExcel;
        private Button buttonLoadingFromExcel;
        private Button buttonAdd;
        private Button buttonChange;
        private Button buttonDelete;
    }
}
