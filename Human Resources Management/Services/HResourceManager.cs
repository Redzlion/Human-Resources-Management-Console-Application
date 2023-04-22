using Project.Enums;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services
{
    class HResourceManager : IHumanResourceManager
    {

        public HResourceManager()
        {
            _employee = new Employee[0];
            _Departments = new Department[0];

        }
        private Department[] _Departments;
        private Employee[] _employee;
        public Department[] Departments { get { return _Departments; } }
        public void AddDepartment(string name, int workerLimit , int salaryLimit)
        {

            Department department = FindDepartmentByName(name);
            
            if (department == null)
            {
                department = new Department(name, workerLimit, salaryLimit );
                Array.Resize(ref _Departments, _Departments.Length + 1);
                _Departments[_Departments.Length - 1] = department;
            }
        }
        public void AddEmployee(string departmentName ,string no, string fullname,EmployeeType position ,int salary)
        {
            Department department = FindDepartmentByName(departmentName);
            if (department == null) return;
            if (department.WorkerLimit <= department.Employees.Length) return;
            Employee employee = new Employee(fullname, no)
            {

                DepartmentName = departmentName,
                Position = position,
                Salary = salary
                
            };
            Array.Resize(ref department.Employees, department.Employees.Length + 1);
            department.Employees[department.Employees.Length - 1] = employee;
        }
        public void EditDepartments(string name, string newName)
        {
            if (FindDepartmentByName(newName) != null) return;
            Department existDepartment = FindDepartmentByName(name);
            if (existDepartment != null)
            {
                existDepartment.Name = newName;
            }
        }
        public void EditEmployee(string no, int salary, EmployeeType position, string newno, int newsalary, EmployeeType newposition)
        {
            salary = newsalary;
            no = newno;
        }
        public Department[] GetDepartments()
        {
            Department[] departments = new Department[0];
            foreach (var item in _Departments )
            {
                Array.Resize(ref departments, departments.Length + 1);
                departments[departments.Length - 1] = item;
            }
            return departments;
        }
        public void RemoveEmployee(string departmentName, string fullname, EmployeeType position)
        {
            throw new NotImplementedException();
        }
        public Employee[] Search(string search, EmployeeType? position)
        {
            Employee[] employees = new Employee [0];
            foreach (var department in _Departments )
            {
                foreach (var emp in department.Employees)
                {
                    if ((emp.Fullname).Contains(search))
                    {
                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = emp;
                    }
                }              
            }
            return employees;
        }
        public Department FindDepartmentByName(string name)
        {
            foreach (var item in _Departments)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public Employee[] GetAllEmployees()
        {
            Employee[] employees = new Employee[0];
            foreach (var group in _Departments)
            {
                foreach (var emp in group.Employees)
                {
                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = (Employee)emp;
                }
            }
            return employees;
        }
        public Employee[] Search(string search)
        {
            throw new NotImplementedException();
        }
        public Department FindEmplyeeByFullname(string fulllname)
        {
            throw new NotImplementedException();
        }
        //public Department FindEmplyeeByFullname(string fullname)
        //{
        //    foreach (var item in _employee)
        //    {
        //        if (item.name == name)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //
        //}
    }
}
