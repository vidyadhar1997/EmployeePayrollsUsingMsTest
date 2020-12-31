using System;

namespace EmployeePyrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePayrollRepo employeeRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeId = 1;
            employeeModel.EmployeeName = "Prem";
            employeeModel.JobDescription = "Mech";
            employeeModel.Month = "Feb";
            employeeModel.EmployeeSalary = 25000;
            employeeModel.SalaryId = 404;
            employeeModel.StartDate = new DateTime(2015,09,12);
            employeeModel.Gender = 'M';
            employeeRepo.addEmployee(employeeModel);
        }
    }
}
