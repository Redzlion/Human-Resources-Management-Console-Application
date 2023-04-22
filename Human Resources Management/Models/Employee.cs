using System;
using System.Collections.Generic;
using System.Text;
using Project.Enums;

namespace Project.Models
{
    class Employee
    {
        public Employee(string fullname,string no)
        {
            this.Fullname = fullname;
            this.No = no;
           
        }
        public Employee(string no)
        {
            No = no;
        }
        public string Fullname;
        public EmployeeType Position;
        public int Salary;
        public string DepartmentName;
        public string No;
        public IEnumerable<object> Employees { get; internal set; }
        public override string ToString()
        {
            return $"FullName : {Fullname} - No : {No} - Position : {Position} - Salary : {Salary}";
        }
    }
}
