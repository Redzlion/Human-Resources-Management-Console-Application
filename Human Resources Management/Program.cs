using System;
using Project.Services;
using Project.Enums;
using Project.Models;
using System.Linq;


namespace Project
{
    

    class Program
    {
         
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            HResourceManager hResourceManager = new HResourceManager();
            hResourceManager.AddDepartment("IT", 7, 10000);
            hResourceManager.AddEmployee("IT", "A2", "Yusif A", 0, 10000);

            string ans;
            do
            {
                Console.WriteLine("\n==============================================\n");

                Console.WriteLine("1.1 - Show The List Of Departments");
                Console.WriteLine("1.2 - To Create A New Department");
                Console.WriteLine("1.3 - To Customize A Department");
                Console.WriteLine("2.1 - Show Thw List Of Employees");
                Console.WriteLine("2.2 - Show Thw List Of Employees In Department");
                Console.WriteLine("2.3 - Add An Employee");
                Console.WriteLine("2.4 - Make Changes On Employee");
                Console.WriteLine("2.5 - Remove Employee from Department");
                Console.WriteLine("2.6 - Search");
                Console.WriteLine("3.0 - Exit The System");

                Console.WriteLine("\nChoose What you Want To Do:");
                ans = Console.ReadLine();

                Console.WriteLine("\n==============================================\n");
                switch (ans)
                {
                    case "1.1":
                        GetDepartments(hResourceManager);
                        break;
                    case "1.2":
                        AddDepartment(hResourceManager);
                        break;
                    case "1.3":
                        EditDepartments(hResourceManager);
                        break;
                    case "2.1":
                        ShowAllEmployees(hResourceManager);
                        break;
                    case "2.2":
                        ShowEmployeesOfGroup(hResourceManager);
                        break;
                    case "2.3":
                        AddEmployee(hResourceManager);
                        break;
                    //case "2.4":
                    //    ShowSearchedEmpolyees(HResourceManager);
                    //    break;
                    //case "2.5":
                    //    RemoveEmployee(hResourceManager);
                    //    break;
                    case "2.6":
                        Search(hResourceManager);
                        break;
                    case "3.0":
                        Exit(hResourceManager);
                        break;
                    default:
                        break;
                }
            } while (ans != "3.0");
        }
        static void GetDepartments(HResourceManager hResourceManager)
        {
            if (hResourceManager.Departments.Length > 0)
            {
                foreach (var item in hResourceManager.Departments)
                {
                    Console.WriteLine($"Name: {item.Name} - WorkerLimit: {item.WorkerLimit} - SalaryLimit: {item.SalaryLimit}");
                }
            }
            else
            {
                Console.WriteLine("Such Department Does Not Exist!");
            }
        }
        static void AddDepartment(HResourceManager hResourceManager)
        {
            string name;
            bool check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter Department Name : ");
                else
                    Console.WriteLine("Department With That Name Already Exists Try A Different One : ");
                name = Console.ReadLine();
                check = false;
                string nameStr;
                int nameInt;


                if (true)
                {

                }
                do
                {
                    Console.WriteLine("Entered Name Is Wrong, Enter Department Name : ");
                    nameStr = Console.ReadLine();
                } while (int.TryParse(nameStr, out nameInt) || string.IsNullOrWhiteSpace(nameStr));



            } while (hResourceManager.FindDepartmentByName(name) != null);
            string workerLimitStr;
            int workerLimitInt;
            do
            {
                Console.WriteLine("Enter Employee Limit : ");
                workerLimitStr = Console.ReadLine();

            } while (!int.TryParse(workerLimitStr, out workerLimitInt));
            string salaryLimitStr;
            int salaryLimitInt;
            do
            {
                Console.WriteLine("Enter Salary Limit : ");
                salaryLimitStr = Console.ReadLine();
            } while (!int.TryParse(salaryLimitStr, out salaryLimitInt));
            hResourceManager.AddDepartment(name, workerLimitInt, salaryLimitInt);
        }
        static void EditDepartments(HResourceManager hResourceManager)
        {
            string name;
            bool check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter The Name Of The Department You Want To Customize :");
                else
                    Console.WriteLine("Entered Department Name Does Not Exist, Please Enter Again:");
                name = Console.ReadLine();
                check = false;
            } while (hResourceManager.FindDepartmentByName(name) == null);
            string newName;
            check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter New Department Name : ");
                else
                    Console.WriteLine("Entered Department Already Exists Enter New One :");
                newName = Console.ReadLine();
                check = false;
                string newnameStr;
                int newnameInt;
                do
                {
                    Console.WriteLine("Entered Name Is Wrong ,Enter Department Name : ");
                    newnameStr = Console.ReadLine();
                } while (int.TryParse(newnameStr, out newnameInt) || string.IsNullOrWhiteSpace(newnameStr));
            } while (hResourceManager.FindDepartmentByName(newName) != null || string.IsNullOrWhiteSpace(newName));
            hResourceManager.EditDepartments(name, newName);
        }
        static void AddEmployee(HResourceManager hResourceManager)
        {
            string no;
            Department department = null;
            bool check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter Department Name :");
                else
                    Console.WriteLine("It's Wrong Enter Again :");
                no = Console.ReadLine();
                department = hResourceManager.FindDepartmentByName(no);
                check = false;
            } while (department == null);

            if (department.WorkerLimit <= department.Employees.Length)
            {
                Console.WriteLine("Employee Limit Is Reached, You Can Not Add Employee");
                return;
            }
            string fullname;
            check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter Fullname :");
                else
                    Console.WriteLine("Enter Fullname In Correct Form (First Letter In Capital Letter And There Should Be Space In Between Name And Surname)");
                fullname = Console.ReadLine();                           
                check = false;
            } while (string.IsNullOrWhiteSpace(fullname) || !(fullname.Length > 3) || !CheckFullname((fullname)));

            int typeInt;
            string typeStr;
            check = true;

            Console.WriteLine("Employee Positons :");
            foreach (var item in Enum.GetValues(typeof(EmployeeType)))
            {
                Console.WriteLine((int)item + " - " + item);
            }
            do
            {
                if (check)
                    Console.WriteLine("Choose Employee's Position :");
                else
                    Console.WriteLine("Enter Correct Position");

                typeStr = Console.ReadLine();
                check = false;
            } while (!int.TryParse(typeStr, out typeInt) || typeInt < 0 || typeInt >= Enum.GetValues(typeof(EmployeeType)).Length);

            string departmentName;
            check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter Department Name That You Want To Add Employee To :");
                else
                    Console.WriteLine("Entered Department Does Not Exist , Please Enter Again :");
                departmentName = Console.ReadLine();
                check = false;
            } while (hResourceManager.FindDepartmentByName(departmentName) == null);

            int salary = 0;
            check = true;
            do
            {
                Console.WriteLine("Enter Employee's Salary :");
                try
                {
                    salary = Convert.ToInt32(Console.ReadLine());
                    if (salary >= 1000)
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Minimum Salary Should Be 1000 USD");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("It's Overlimit");
                }
            } while (check);

            hResourceManager.AddEmployee(departmentName, no, fullname, (EmployeeType)typeInt, salary);
        }
        static void ShowEmployeesOfGroup(HResourceManager hResourceManager)
        {
            string no;
            bool check = true;
            Department department = null;
            do
            {
                if (check)
                    Console.WriteLine("Enter Department Name :");
                else
                    Console.WriteLine("Entered Department Name Does Not Exist , Please Enter Again :");
                no = Console.ReadLine();
                department = hResourceManager.FindDepartmentByName(no);
                check = false;
            } while (department == null);

            if (department.Employees.Length > 0)
            {
                Console.WriteLine("==============================================\n");
                Console.WriteLine($"{no} Group's Employees: \n ");
                foreach (var item in department.Employees)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("==============================================\n");
                Console.WriteLine("There Are Not Any Employees In Entered Department");
            }
        }
        static void ShowAllEmployees(HResourceManager hResourceManager)
        {
            var employees = hResourceManager.GetAllEmployees();
            if (employees.Length > 0)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("All Employees:\n");
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);
                }
            }
            else
            {
                Console.WriteLine("There Are Not Any Employees In The System");
            }
        }
        static void Search(HResourceManager hResourceManager)
        {
            string search;
            do
            {
                Console.WriteLine("Enter FullName Of The Employee You want To Search : ");
                search = Console.ReadLine();

            } while (string.IsNullOrEmpty(search));

            EmployeeType? position = null;
            string positionStr;

            Console.WriteLine("Do You Want To Search Employee By His/Her Position ?  y/n");
            positionStr = Console.ReadLine();

            if (positionStr == "y")
            {
                Console.WriteLine("Sistemdeki ... -lar ");
                foreach (var item in Enum.GetValues(typeof(EmployeeType)))
                {
                    Console.WriteLine((int)item + " - " + item);
                }
                int positionInt;
                do
                {
                    Console.WriteLine("Choose: ");
                    positionStr = Console.ReadLine();

                } while (!int.TryParse(positionStr, out positionInt) || positionInt < 0 || positionInt >= Enum.GetValues(typeof(EmployeeType)).Length);
                position = (EmployeeType)positionInt;
            }
            var searchedEmplyees = hResourceManager.Search(search, position);
            if (searchedEmplyees.Length > 0)
            {
                Console.WriteLine("Employees: \n");
                foreach (var item in searchedEmplyees)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("==============================================\n");
                Console.WriteLine("There Are Not Employees According To Your Search");
            }
        }
        static void Exit(HResourceManager hResourceManager)
        {
            Console.WriteLine("You Exited The System.");
            Environment.Exit(0);
        }
        static void RemoveEmployee(HResourceManager hResourceManager)
        {
            string no;
            Department department = null;
            bool check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter The Department Name Of The Employee That You Want To Remove :");
                else
                    Console.WriteLine("Wrong , Please Enter Again :");
                no = Console.ReadLine();
                department = hResourceManager.FindDepartmentByName(no);
                check = false;
            } while (department == null);

            //string fulllname;
            //Employee employee = null;
            //check = true;
            //do
            //{
            //    if (check)
            //        Console.WriteLine("Silmek Istediyiniz Employeenin Departmentini Daxil Edin :");
            //    else
            //        Console.WriteLine("Sehvdir ,Yeniden Daxil Edin :");
            //    fulllname = Console.ReadLine();
            //    employee  = hResourceManager.FindEmplyeeByFullname(fulllname);
            //    check = false;
            //} while (employee == null);

            //if (department.WorkerLimit <= department.Employees.Length)
            //{
            //    Console.WriteLine("Employee Limiti minimum 1 olmalidir , Employee Sile Bilmersen");
            //    return;
            //}
            string fullname;
            check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter The FullName Of The Employee That You Want To Remove:");
                else
                    Console.WriteLine("Enter Fullname In Correct Form (First Letter In Capital Letter And There Should Be Space In Between Name And Surname");
                fullname = Console.ReadLine();
                check = false;
            } while (string.IsNullOrWhiteSpace(fullname) || !(fullname.Length > 3) || !CheckFullname((fullname)));



            int typeInt;
            string typeStr;
            check = true;

            Console.WriteLine("Employee Positons :");
            foreach (var item in Enum.GetValues(typeof(EmployeeType)))
            {
                Console.WriteLine((int)item + " - " + item);
            }
            do
            {
                if (check)
                    Console.WriteLine("Choose Employee Position :");
                else
                    Console.WriteLine("Enter True Position ");

                typeStr = Console.ReadLine();
                check = false;
            } while (!int.TryParse(typeStr, out typeInt) || typeInt < 0 || typeInt >= Enum.GetValues(typeof(EmployeeType)).Length);

            string departmentName;
            check = true;
            do
            {
                if (check)
                    Console.WriteLine("Enter Department Name That You Want To Remove Employee From :");
                else
                    Console.WriteLine("Entered Department Name Does Not Exist , Please Enter Again :");
                departmentName = Console.ReadLine();
                check = false;
            } while (hResourceManager.FindDepartmentByName(departmentName) == null);

            hResourceManager.RemoveEmployee(departmentName, fullname, (EmployeeType)typeInt);
        }
        public static bool CheckFullname(string FullName)
        {
            
        int checking = 0;
        bool tf = false;
        bool space = false;
        try
        {
            for (int g = 0; g < 2; g++)
            {

                if (char.IsUpper(FullName[checking]))
                {
                    for (int i = 0; i < FullName.Length - 1 - checking; i++)
                    {
                        if (char.IsLower(FullName[checking + 1 + i]))
                        {
                            tf = true;
                        }
                        else if (char.IsWhiteSpace(FullName[checking + 1 + i]))
                        {
                                checking = checking + 2 + i;
                            if (FullName.Length <= checking)
                            {
                                return false;
                            }
                            tf = true;
                            space = true;
                            break;
                        }
                        else
                        {
                            tf = false;
                            return tf;
                        }
                    }
                }
                else
                {
                    tf = false;
                    break;
                }
            }
            return tf && space;
        }
        catch (Exception)
        {
            return false;
        }
            
        }
    }
}
