using Employees_ICS.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace Employees_ICS
{
    public partial class EmployeeForm : Form
    {
        private readonly BindingSource _bsEmployee = new BindingSource();

        public EmployeeForm()
        {
            InitializeComponent();
            SetBindings();
            this.Load += EmployeeForm_Load;
            okButton.Click += (s, e) => this.DialogResult = DialogResult.OK;
        }


        private void SetBindings()
        {
            _bsEmployee.DataSource = typeof(Employee);

            textBox1.DataBindings.Add("Text", _bsEmployee, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", _bsEmployee, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBox1.DataBindings.Add("Text", _bsEmployee, "Position", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePicker1.DataBindings.Add("Value", _bsEmployee, "DateBirth", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox3.DataBindings.Add("Text", _bsEmployee, "Salary", true, DataSourceUpdateMode.OnPropertyChanged);

            errorProvider1.DataSource = _bsEmployee;
            _bsEmployee.CurrentItemChanged += BsEmployee_CurrentItemChanged;
        }

        private void BsEmployee_CurrentItemChanged(object sender, EventArgs e)
        {
            string errors = String.Empty;

            foreach (var txtBox in Controls.OfType<TextBox>())
            {
                errors += errorProvider1.GetError(txtBox);
            }
            //Enabled-Disabled button OK
            okButton.Enabled = String.IsNullOrEmpty(errors);
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
       


        public Employee CurrentEmployee
        {
            get => (Employee)_bsEmployee.Current;
            set
            {
                _bsEmployee.Clear();
                _bsEmployee.Add(value);
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            Program.Context.FillComboPositions(comboBox1);
            this.CancelButton = cancelButton;
            this.AcceptButton = okButton;
            this.BackColor = Color.AntiqueWhite;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}

