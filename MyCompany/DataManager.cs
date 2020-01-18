using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MyCompany
{
    class DataManager
    {
        private BinaryFormatter bf = new BinaryFormatter();

        private string path1 = @"..\..\Data\departments.dat";
        private string path2 = @"..\..\Data\employees.dat";

        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }

        public DataManager()
        {
            Departments = new List<Department>();
            Employees = new List<Employee>();
            // Only once!!!
            // ---------------
            // InitData();
            // SaveDepartments();
            // SaveEmployees();
            // ---------------
            LoadDepartments();
            LoadEmployees();
        }

        private void LoadDepartments()
        {
            using (FileStream fs = new FileStream(path1, FileMode.Open))
            {
                Departments = (List<Department>)bf.Deserialize(fs);
            }
        }

        private void LoadEmployees()
        {
            using (FileStream fs = new FileStream(path2, FileMode.Open))
            {
                Employees = (List<Employee>)bf.Deserialize(fs);
            }
        }

        private void SaveDepartments()
        {
            using (FileStream fs = new FileStream(path1, FileMode.Create))
            {
                bf.Serialize(fs, Departments);
            }
        }

        private void SaveEmployees()
        {
            using (FileStream fs = new FileStream(path2, FileMode.Create))
            {
                bf.Serialize(fs, Employees);
            }
        }

        private void InitData()
        {
            Departments.Add(new Department { Id = 1, Name = "Компьютерный отдел" });
            Departments.Add(new Department { Id = 2, Name = "Финансовый отдел" });
            Departments.Add(new Department { Id = 3, Name = "Юридический отдел" });

            Employees.Add(new Employee
            {
                Id = 1,
                Name = "Иваненко Иван",
                Photo = @"..\..\Photo\p1.jpg",
                Birth = new DateTime(1990, 1, 15),
                Entry = new DateTime(2015, 3, 3),
                Fire = "-",
                Position = "разработчик",
                Salary = 2000,
                DepId = 1
            });

            Employees.Add(new Employee
            {
                Id = 2,
                Name = "Петренко Петр",
                Photo = @"..\..\Photo\p2.jpg",
                Birth = new DateTime(1995, 10, 20),
                Entry = new DateTime(2015, 3, 4),
                Fire = "-",
                Position = "бухгалтер",
                Salary = 1200,
                DepId = 2
            });

            Employees.Add(new Employee
            {
                Id = 3,
                Name = "Сидоренко Сидор",
                Photo = @"..\..\Photo\p3.jpg",
                Birth = new DateTime(1992, 7, 5),
                Entry = new DateTime(2015, 3, 5),
                Fire = "-",
                Position = "юрист",
                Salary = 1500,
                DepId = 3
            });
        }
    }
}
