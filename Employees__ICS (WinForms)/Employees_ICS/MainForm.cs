using Employees_ICS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Employees_ICS
{
    public partial class MainForm : Form
    {
        private readonly BindingSource _bsCollective = new BindingSource();


        public MainForm()
        {            
            InitializeComponent();
            this.Load += LoadForm;           
        }


        private void SetBindings()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _bsCollective;
        }


        private void LoadData()
        {
            string position = comboBox1.Text;
            List<Employee> _employeesList = Program.Context.GetAll(position);
            _bsCollective.Clear();
            _employeesList.ForEach(e => _bsCollective.Add(e));
            _bsCollective.ResetBindings(false);
        }

        
        private void ReportButton_Click(object sender, EventArgs e)
        {
            Report form = new Report();
            form.Show(this);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using(var newEmpForm = new EmployeeForm())
            {
                newEmpForm.Owner = this;
                newEmpForm.Text = "Create New Employee";
                newEmpForm.Controls[3].Text = "Add";

                newEmpForm.CurrentEmployee = new Employee
                {
                    FirstName = Employee.Dummy,
                    LastName = Employee.Dummy,
                    Position = "Trainee",
                    DateBirth = new DateTime(),
                    Salary = 0
                };

                if(newEmpForm.ShowDialog() == DialogResult.OK)
                {
                    Program.Context.AddEmployee(newEmpForm.CurrentEmployee);
                    LoadData();
                }
            }           
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            using(EmployeeForm editEmpForm = new EmployeeForm())
            {
                editEmpForm.Owner = this;
                editEmpForm.Controls[3].Text = "Edit";


                var selectEmployee = _bsCollective.Current as Employee;
                editEmpForm.CurrentEmployee = new Employee
                {
                    Id = selectEmployee.Id,
                    FirstName = selectEmployee.FirstName,
                    LastName = selectEmployee.LastName,
                    Position = selectEmployee.Position,
                    DateBirth = selectEmployee.DateBirth,
                    Salary = selectEmployee.Salary
                };

                editEmpForm.Text = $"Edit {selectEmployee.FirstName} {selectEmployee.LastName}";
                if(editEmpForm.ShowDialog() == DialogResult.OK)
                {
                    Program.Context.UpdateEmployee(editEmpForm.CurrentEmployee);
                    LoadData();
                }
            }            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectEmployee = _bsCollective.Current as Employee;
                if (MessageBox.Show($"Remove employee <<{selectEmployee.FirstName} {selectEmployee.LastName}>>" +
                    $" ?\n\nContinue?", "Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Program.Context.DeleteEmployee(selectEmployee.Id);
                    LoadData();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Select the desired record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /*
        private void FillComboPositions()
        {
            using (SqlConnection connect = new SqlConnection(connectStr))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM positions", connect);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                comboBox1.Items.Clear();
                comboBox1.Items.Add("- All -");

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }

                comboBox1.SelectedIndex = 0;
            }                
        }*/

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            Program.Context.FillComboPositions(comboBox1);
            SetBindings();            
            LoadData();
        }


        static void ToggleConfigEncryption(string exeFile)
        {
            try
            {
                Configuration config = ConfigurationManager.
                    OpenExeConfiguration(exeFile);

                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;

                if (section.SectionInformation.IsProtected)
                {
                    // Remove encryption.
                    section.SectionInformation.UnprotectSection();
                }
                else
                {
                    // Encrypt the section.
                    section.SectionInformation.ProtectSection(
                        "DataProtectionConfigurationProvider");
                }
                config.Save();

                Console.WriteLine("Protected={0}",
                    section.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
