using EmployeePyrolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        /// <summary>
        /// Givens the employee name when update salary then return expected salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeName_WhenUpdateSalary_ThenReturnExpectedSalary()
        {
            int expected = 3000000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.updateEmployee();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Givens the name of the employee names when in given range then return count by employee.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenInGivenRange_ThenReturnCountByEmployeeName()
        {
            int expected =2;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Givens the employee names when update salary then return expected sum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenUpdateSalary_ThenReturnExpectedSumSalary()
        {
            int expected = 7000000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int sum = employeePayrollRepo.getAggrigateSumSalary();
            Assert.AreEqual(expected, sum);
        }

        /// <summary>
        /// Givens the employee names when average salary then return expected average salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenAvgSalary_ThenReturnExpectedAvgSalary()
        {
            int expected = 3500000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int avg = employeePayrollRepo.getAvragSalary();
            Assert.AreEqual(expected, avg);
        }

        /// <summary>
        /// Givens the employee names when minimum salary then return expected minimum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMinSalary_ThenReturnExpectedMinSalary()
        {
            int expected = 3000000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int min = employeePayrollRepo.getMinSalary();
            Assert.AreEqual(expected, min);
        }

        /// <summary>
        /// Givens the employee names when maximum then return expected maximum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMax_ThenReturnExpectedMaxSalary()
        {
            int expected = 4000000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int max = employeePayrollRepo.getMaxSalary();
            Assert.AreEqual(expected, max);
        }

        /// <summary>
        /// Givens the employee names when count by salary then return expected count by salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenCountBySalary_ThenReturnExpectedCountBySalary()
        {
            int expected = 2;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getCountSalary();
            Assert.AreEqual(expected, count);
        }
        
        /// <summary>
        /// Givens the employee names when count by salary then return expected count by salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNamess_WhenCountBySalary_ThenReturnExpectedCountBySalary()
        {
            bool expected = true;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 5,
                EmployeeName = "Prem",
                JobDescription = "Mech",
                Month = "Feb",
                EmployeeSalary = 25000,
                SalaryId = 404,
                StartDate = new DateTime(2015,09,12),
                Gender = 'M'
            };
            bool result = employeePayrollRepo.addEmployee(model);
            Assert.AreEqual(expected, result);
        }
    }
}
