using System;

namespace EmployeePyrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            employeeModel.EmployeeId = 1;
            employeePayrollRepo.CheckEmployeeIsActive(employeeModel);
        }
    }
}
