using System;
using System.Collections.Generic;
using System.Text;
using Project.Enums;

namespace Project.Models
{
    class Department
    {
        public string Name;
        public int WorkerLimit;
        public int SalaryLimit;
        public Employee[] Employees = new Employee[0];
        public Department(string name, int workerLimit, int salaryLimit )
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
        }
        public int CalcSalaryAverage()
        {
            int sum = 0;
            for (int i = 0; i < Employees.Length; i++)
            {
                sum += Employees[i].Salary;
            }
            sum /= Employees.Length;
            return sum;
        }
    }
}
