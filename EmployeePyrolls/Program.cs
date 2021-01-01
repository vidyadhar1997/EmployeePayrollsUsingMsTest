using System;

namespace EmployeePyrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePayrollRepo employeeRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeId = 83;
            employeeModel.EmployeeName = "Prem";
            employeeModel.JobDescription = "Mech";
            employeeModel.Month = "Feb";
            employeeModel.EmployeeSalary = 25000;
            employeeModel.SalaryId = 504;
            employeeModel.StartDate = new DateTime(2015, 09, 12);
            employeeModel.Gender = 'M';
            employeeModel.DepartmentId = 2;
            employeeModel.CompanyId = 3;
            employeeRepo.addEmployeeToPayroll(employeeModel);
        }
    }
}
