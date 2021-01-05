using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePyrolls
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
        EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
        
        /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeelist">The employeelist.</param>
        public void addEmployeeToPayroll(List<EmployeeModel> employeelist)
        {
            employeelist.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added = " + employeeData.EmployeeName);
                this.addEmployeeToPayroll(employeeData);
                Console.WriteLine("Employee added =" + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeeModelList.ToString());
        }
        
       /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeeData">The employee data.</param>
        public void addEmployeeToPayroll(EmployeeModel employeeData)
        {
            employeeModelList.Add(employeeData);

        }
    }
}
