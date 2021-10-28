using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Employee Payroll Service : The Data From DataBase!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            //employee.Id = 7;
            employee.EmpName = "Kavita";
            employee.BasicPay = 45000;
            employee.StartDate = Convert.ToDateTime("2021-10-25 20:50:42.773");
            employee.Gender = "F";
            employee.PhoneNumber = "8123236115";
            employee.Department = "HR";
            employee.Address = "Bangalore";
            employee.Deduction = 200;
            employee.TaxablePay = 4000;
            employee.IncomeTax = 3000;
            employee.NetPay = 1500;

            employeeRepo.AddEmployee(employee);

            //employeeRepo.GetAllEmployees();
        }
    }
}
