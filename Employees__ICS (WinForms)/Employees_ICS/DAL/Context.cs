using Employees_ICS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Employees_ICS.DAL
{
    class DbContext
    {
        private List<Employee> _collective;
        private readonly string connectStr = GetConnectionStringByName("connectStr_1");
        //ctor
        public DbContext() { }


        private static string GetConnectionStringByName(string name)
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                return settings.ConnectionString;
            else
                return null;
        }


        internal List<Employee> GetAll(string position)
        {
            try
            {
                using(var connect = new SqlConnection(connectStr))
                {
                    string filter = "";
                    if (position != "- All -") 
                        filter += " WHERE position ='" + position + "'";


                    connect.Open();
                    using (var cmd = new SqlCommand($@"SELECT * FROM employees{filter};", connect))
                    {
                        using(var reader = cmd.ExecuteReader())
                        {
                            _collective = new List<Employee>();
                            while (reader.Read())
                            {
                                _collective.Add(new Employee
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Position = reader.GetString(3),
                                    DateBirth = reader.GetDateTime(4),
                                    Salary = (uint)reader.GetInt32(5)
                                });
                            }

                            return _collective;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        internal bool AddEmployee(Employee employee)
        {
            try
            {
                using (var connect = new SqlConnection(connectStr))
                {
                    connect.Open();

                    SqlCommand cmd = new SqlCommand($@"INSERT INTO employees (
                      firstName,
                      lastName,
                      position,
                      dateBirth,
                      salary
                  )
                  VALUES (
                      '{employee.FirstName}',
                      '{employee.LastName}',
                      '{employee.Position}',
                      '{employee.DateBirth:yyyy-MM-dd}',
                      '{employee.Salary}');", connect);

                    var res = cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        internal bool UpdateEmployee(Employee currEmployee)
        {
            try
            {
                using(var connect = new SqlConnection(connectStr))
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand($@"UPDATE employees SET 
                                                    firstName = '{currEmployee.FirstName}',
                                                    lastName = '{currEmployee.LastName}',
                                                    position = '{currEmployee.Position}',
                                                    dateBirth = '{currEmployee.DateBirth:yyyy-MM-dd}',
                                                    salary = '{currEmployee.Salary}'
                                                    WHERE id = {currEmployee.Id};", connect);

                    
                    var res = cmd.ExecuteNonQuery();
                    return true;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }


        internal bool DeleteEmployee(int id)
        {
            try
            {
                using(var connect = new SqlConnection(connectStr))
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(
                        $"DELETE FROM employees WHERE id = {id};", connect);
                    
                    var res = cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.Message);
                return false; }            
        }

        internal void FillComboPositions(ComboBox cb)
        {
            using (SqlConnection connect = new SqlConnection(connectStr))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM positions", connect);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cb.Items.Clear();
                cb.Items.Add("- All -");

                while (reader.Read())
                {
                    cb.Items.Add(reader[0]);
                }

                cb.SelectedIndex = 0;
            }
        }
    }
}
