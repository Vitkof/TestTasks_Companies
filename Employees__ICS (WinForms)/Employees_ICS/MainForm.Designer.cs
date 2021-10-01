
namespace Employees_ICS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBirthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, System.Drawing.FontStyle.Bold);
            this.editButton.Location = new System.Drawing.Point(636, 198);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(152, 51);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, System.Drawing.FontStyle.Bold);
            this.deleteButton.Location = new System.Drawing.Point(636, 255);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(152, 48);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, System.Drawing.FontStyle.Bold);
            this.reportButton.Location = new System.Drawing.Point(636, 309);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(152, 46);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstNameColumn,
            this.LastNameColumn,
            this.PositionColumn,
            this.DateBirthColumn,
            this.SalaryColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(618, 315);
            this.dataGridView1.TabIndex = 3;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First Name";
            this.FirstNameColumn.Name = "FirstNameColumn";
            this.FirstNameColumn.ReadOnly = true;
            this.FirstNameColumn.Width = 120;
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last Name";
            this.LastNameColumn.Name = "LastNameColumn";
            this.LastNameColumn.ReadOnly = true;
            this.LastNameColumn.Width = 130;
            // 
            // PositionColumn
            // 
            this.PositionColumn.DataPropertyName = "Position";
            this.PositionColumn.HeaderText = "Position";
            this.PositionColumn.Name = "PositionColumn";
            this.PositionColumn.ReadOnly = true;
            this.PositionColumn.Width = 140;
            // 
            // DateBirthColumn
            // 
            this.DateBirthColumn.DataPropertyName = "DateBirth";
            this.DateBirthColumn.HeaderText = "Date of Birth";
            this.DateBirthColumn.Name = "DateBirthColumn";
            this.DateBirthColumn.ReadOnly = true;
            this.DateBirthColumn.Width = 120;
            // 
            // SalaryColumn
            // 
            this.SalaryColumn.DataPropertyName = "Salary";
            this.SalaryColumn.HeaderText = "Salary";
            this.SalaryColumn.Name = "SalaryColumn";
            this.SalaryColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Position";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "- All -";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, System.Drawing.FontStyle.Bold);
            this.addButton.Location = new System.Drawing.Point(636, 141);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(152, 51);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add ";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 378);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Employees";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBirthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalaryColumn;
    }
}
