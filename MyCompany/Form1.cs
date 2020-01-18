using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace MyCompany
{
    public partial class Form1 : Form
    {
        private DataManager dm = new DataManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void FillDepartments()
        {
            var deps = dm.Departments.ToList();
            depList.Items.Clear();
            foreach (var dep in deps)
            {
                depList.Items.Add(dep);
            }
            depList.DisplayMember = "Name";
            depList.SelectedIndex = 0;
        }

        private void FillEmployees(int dep_id)
        {
            var emps = dm.Employees.Where(x => x.DepId == dep_id).ToList();
            empList.Items.Clear();
            foreach (var emp in emps)
            {
                empList.Items.Add(emp);
            }
            empList.DisplayMember = "Name";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDepartments();
        }

        private void depList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elem = depList.SelectedItem as Department;
            int id = elem.Id;
            FillEmployees(id);
        }

        private void empList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elem = empList.SelectedItem as Employee;
            int emp_id = elem.Id;
            photo.Image = Image.FromFile(elem.Photo);
            name.Text = elem.Name;
            birth.Value = elem.Birth;
            entry.Value = elem.Entry;
            fire.Text = elem.Fire;
            pos.Text = elem.Position;
            salary.Text = elem.Salary.ToString();
        }
    }
}
