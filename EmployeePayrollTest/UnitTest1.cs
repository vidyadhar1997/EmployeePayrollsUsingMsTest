using EmployeePyrolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the employee payroll when retrieve then return employee payroll from data base.
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenRetrieve_ThenReturnEmployeePayrollFromDataBase()
        {
            int expected = 2;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getAllEmployee();
            Assert.AreEqual(expected, count);
        }
    }
}
