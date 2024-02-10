namespace WinFormsAppPLMUral
{
    partial class FormEditingAndAddingDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelName = new Label();
            textBoxName = new TextBox();
            buttonOK = new Button();
            buttonСancel = new Button();
            dataGridViewDetailsSelector = new DataGridView();
            Detail = new DataGridViewComboBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            Remove = new DataGridViewButtonColumn();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailsSelector).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(9, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(90, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(105, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(9, 226);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonСancel
            // 
            buttonСancel.DialogResult = DialogResult.Cancel;
            buttonСancel.Location = new Point(497, 226);
            buttonСancel.Name = "buttonСancel";
            buttonСancel.Size = new Size(75, 23);
            buttonСancel.TabIndex = 5;
            buttonСancel.Text = "Отмена";
            buttonСancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDetailsSelector
            // 
            dataGridViewDetailsSelector.AllowUserToAddRows = false;
            dataGridViewDetailsSelector.AllowUserToDeleteRows = false;
            dataGridViewDetailsSelector.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetailsSelector.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetailsSelector.Columns.AddRange(new DataGridViewColumn[] { Detail, Count, Remove });
            dataGridViewDetailsSelector.Location = new Point(12, 35);
            dataGridViewDetailsSelector.Name = "dataGridViewDetailsSelector";
            dataGridViewDetailsSelector.Size = new Size(397, 150);
            dataGridViewDetailsSelector.TabIndex = 6;
            dataGridViewDetailsSelector.CellClick += dataGridViewDetailsSelector_CellClick;
            dataGridViewDetailsSelector.DataError += dataGridViewDetailsSelector_DataError;
            dataGridViewDetailsSelector.RowsAdded += dataGridViewDetailsSelector_RowsAdded;
            dataGridViewDetailsSelector.RowsRemoved += dataGridViewDetailsSelector_RowsRemoved;
            // 
            // Detail
            // 
            Detail.HeaderText = "Detail";
            Detail.Name = "Detail";
            // 
            // Count
            // 
            Count.HeaderText = "Count";
            Count.Name = "Count";
            // 
            // Remove
            // 
            Remove.HeaderText = "Remove";
            Remove.Name = "Remove";
            Remove.Text = "Remove";
            Remove.UseColumnTextForButtonValue = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(9, 191);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormEditingAndAddingDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewDetailsSelector);
            Controls.Add(buttonСancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Name = "FormEditingAndAddingDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Работа с деталями";
            Shown += FormEditingAndAddingDetails_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailsSelector).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Button buttonOK;
        private Button buttonСancel;
        public TextBox textBoxName;
        private DataGridView dataGridViewDetailsSelector;
        private Button buttonAdd;
        private DataGridViewComboBoxColumn Detail;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewButtonColumn Remove;
    }
}