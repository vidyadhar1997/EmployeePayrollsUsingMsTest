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
        public void GivenEmployeePayroll_WhenRetrieve_ThenShouldReturnEmployeePayrollFromDataBase()
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
        public void GivenEmployeeName_WhenUpdateSalary_ThenShouldReturnExpectedSalary()
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
        public void GivenEmployeeNames_WhenInGivenRange_ThenShouldReturnCountByEmployeeName()
        {
            int expected = 2;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Givens the employee names when update salary then return expected sum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenUpdateSalary_ThenShouldReturnExpectedSumSalary()
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
        public void GivenEmployeeNames_WhenAvgSalary_ThenShouldReturnExpectedAvgSalary()
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
        public void GivenEmployeeNames_WhenMinSalary_ThenShouldReturnExpectedMinSalary()
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
        public void GivenEmployeeNames_WhenMax_ThenShouldReturnExpectedMaxSalary()
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
        public void GivenEmployeeNames_WhenCountBySalary_ThenShouldReturnExpectedCountBySalary()
        {
            int expected = 2;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getCountSalary();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Given Employee Payroll When Add New Employee Then should Return Expected Result
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenAddNewEmployee_ThenshouldReturnExpectedResult()
        {
            bool expected = true;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 61,
                EmployeeName = "priya",
                JobDescription = "hr",
                Month = "Feb",
                EmployeeSalary = 25000,
                SalaryId = 404,
                StartDate = new DateTime(2015, 09, 12),
                Gender = 'F'
            };
            bool result = employeePayrollRepo.addEmployeeToPayroll(model);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Given Employee Payroll When Add New Employee Then should Return Expected Result
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenAddInTable_ThenshouldReturnExpectedResults()
        {
            bool expected = true;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 70,
                EmployeeName = "kaajol",
                JobDescription = "sale",
                Month = "Feb",
                EmployeeSalary = 25000,
                SalaryId = 404,
                StartDate = new DateTime(2015, 09, 12),
                Gender = 'F'
            };
            bool result = employeePayrollRepo.addEmployeeToPayroll(model);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// UC10 Given Employee Payroll When Add New Employee Then should Return Expected Result
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ThenshouldPerformInsertion()
        {
            bool expected = true;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 90,
                EmployeeName = "summet",
                JobDescription = "Hr",
                Month = "Feb",
                EmployeeSalary = 25000,
                SalaryId = 404,
                StartDate = new DateTime(2015, 09, 12),
                Gender = 'M',
                CompanyId = 2,
                DepartmentId = 3
            };
            bool result = employeePayrollRepo.addEmployeeToPayroll(model);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// UC10 Given Query When Insert Then should Perform Retrival Operation.
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ThenshouldPerformRetrivalOperation()
        {
            int expected = 12;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getAllEmployee();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// UC10 Given Query When Insert Then should Perform Update Operation.
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ThenshouldPerformUpdateOperation()
        {
            int expected = 3000000;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.updateEmployee();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// UC10 Given Query When Insert Then should Perform get Employee Data With Given Rang.
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ThenshouldPerformgetEmployeeDataWithGivenRange()
        {
            int expected = 12;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            int count = employeePayrollRepo.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expected, count);
        }
        
        /// <summary>
        /// UC11 Given Employee Payroll When Add New Employee Then should Return Expected Results
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenAddInTable_ThenshouldReturnExpectedResultss()
        {
            bool expected = true;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 92,
                EmployeeName = "vidyadhar",
                JobDescription = "Hr",
                Month = "may",
                EmployeeSalary = 25000,
                SalaryId = 404,
                StartDate = new DateTime(2015, 09, 12),
                Gender = 'M',
                CompanyId = 2,
                DepartmentId = 3
            };
            bool result = employeePayrollRepo.addEmployeeToPayroll(model);
            Assert.AreEqual(expected, result);
        }
        
        /// <summary>
        /// Given Employee Payroll When Add New Employee Then should Return Expected Result
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenAddInTable_ThenshouldReturnExpectedResultds()
        {
            int expected = 13;
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel model = new EmployeeModel
            {
                EmployeeId = 1,
            };
            int result = employeePayrollRepo.CheckEmployeeIsActive(model);
            Assert.AreEqual(expected, result);
        }
    }
}