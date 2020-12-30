using System;

namespace EmployeePyrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To the Employee Payrolls");
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            employeePayrollRepo.checkConnection();
        }
    }
}
