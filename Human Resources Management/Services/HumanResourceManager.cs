using System;
using System.Collections.Generic;
using System.Text;
using Project.Models;
using Project.Enums;

namespace Project.Services
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name, int workerLimit, int salaryLimit);
        Department[] GetDepartments();
        void EditDepartments(string name, string newName);
        void AddEmployee(string no, string fullname, string departmentName , EmployeeType position ,int salary);
        void RemoveEmployee(string departmentName, string fullname, EmployeeType position);
        void EditEmployee(string no, int salary, EmployeeType position, string newno, int newsalary, EmployeeType newposition);
        Department FindDepartmentByName(string name);
        Department FindEmplyeeByFullname(string fulllname);
        Employee[] Search(string search);
        Employee[] GetAllEmployees();
    }
}
