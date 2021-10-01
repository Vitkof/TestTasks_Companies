using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_ICS
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TestDBDataSet.employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.TestDBDataSet.employees);

            this.reportViewer1.RefreshReport();
        }
    }
}
