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
            labelQuantity = new Label();
            textBoxName = new TextBox();
            textBoxQuantity = new TextBox();
            buttonOK = new Button();
            buttonСancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 28);
            labelName.Name = "labelName";
            labelName.Size = new Size(90, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(12, 71);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(72, 15);
            labelQuantity.TabIndex = 1;
            labelQuantity.Text = "Количество";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(108, 25);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(108, 68);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(100, 23);
            textBoxQuantity.TabIndex = 3;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(12, 129);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonСancel
            // 
            buttonСancel.DialogResult = DialogResult.Cancel;
            buttonСancel.Location = new Point(197, 129);
            buttonСancel.Name = "buttonСancel";
            buttonСancel.Size = new Size(75, 23);
            buttonСancel.TabIndex = 5;
            buttonСancel.Text = "Отмена";
            buttonСancel.UseVisualStyleBackColor = true;
            // 
            // FormEditingAndAddingDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(buttonСancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxName);
            Controls.Add(labelQuantity);
            Controls.Add(labelName);
            Name = "FormEditingAndAddingDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Работа с деталями";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelQuantity;
        private Button buttonOK;
        private Button buttonСancel;
        public TextBox textBoxName;
        public TextBox textBoxQuantity;
    }
}