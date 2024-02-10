
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
            buttonExportToExcel = new Button();
            buttonImportFromExcel = new Button();
            buttonAdd = new Button();
            buttonChange = new Button();
            buttonDelete = new Button();
            treeViewAssemblyUnits = new TreeView();
            listViewAssemblyUnits = new ListView();
            SuspendLayout();
            // 
            // buttonExportToExcel
            // 
            buttonExportToExcel.Location = new Point(12, 526);
            buttonExportToExcel.Name = "buttonExportToExcel";
            buttonExportToExcel.Size = new Size(117, 23);
            buttonExportToExcel.TabIndex = 1;
            buttonExportToExcel.Text = " Экспорт в Excel";
            buttonExportToExcel.UseVisualStyleBackColor = true;
            buttonExportToExcel.Click += buttonUploadToExcel_Click;
            // 
            // buttonImportFromExcel
            // 
            buttonImportFromExcel.Location = new Point(135, 526);
            buttonImportFromExcel.Name = "buttonImportFromExcel";
            buttonImportFromExcel.Size = new Size(112, 23);
            buttonImportFromExcel.TabIndex = 2;
            buttonImportFromExcel.Text = "Импорт из Excel";
            buttonImportFromExcel.UseVisualStyleBackColor = true;
            buttonImportFromExcel.Click += buttonLoadingFromExcel_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(258, 474);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(117, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(392, 503);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(117, 23);
            buttonChange.TabIndex = 4;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(392, 474);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(117, 23);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // treeViewAssemblyUnits
            // 
            treeViewAssemblyUnits.Location = new Point(12, 12);
            treeViewAssemblyUnits.Name = "treeViewAssemblyUnits";
            treeViewAssemblyUnits.Size = new Size(240, 456);
            treeViewAssemblyUnits.TabIndex = 9;
            // 
            // listViewAssemblyUnits
            // 
            listViewAssemblyUnits.Location = new Point(258, 12);
            listViewAssemblyUnits.Name = "listViewAssemblyUnits";
            listViewAssemblyUnits.Size = new Size(251, 456);
            listViewAssemblyUnits.TabIndex = 10;
            listViewAssemblyUnits.UseCompatibleStateImageBehavior = false;
            // 
            // FormAssemblyUnitStructure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(listViewAssemblyUnits);
            Controls.Add(treeViewAssemblyUnits);
            Controls.Add(buttonDelete);
            Controls.Add(buttonChange);
            Controls.Add(buttonAdd);
            Controls.Add(buttonImportFromExcel);
            Controls.Add(buttonExportToExcel);
            Name = "FormAssemblyUnitStructure";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Структура сборочной единицы";
            FormClosing += FormAssemblyUnitStructure_FormClosing;
            Load += FormAssemblyUnitStructure_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button buttonExportToExcel;
        private Button buttonImportFromExcel;
        private Button buttonAdd;
        private Button buttonChange;
        private Button buttonDelete;
        private TreeView treeViewAssemblyUnits;
        private ListView listViewAssemblyUnits;
    }
}
