using EmployeePyrolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollTest
{
    [TestClass]
    public class EmployeePayrollThreadTest
    {
        /// <summary>
        /// given list and db when insert then calculate execution time
        /// </summary>
        [TestMethod]
        public void givenListAndDb_WhenInsert_ThenCalculateExacutionTime()
        {
            List<EmployeeModel> emploeeModellist = new List<EmployeeModel>();
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 12, EmployeeName = "Dhiraj", JobDescription = "Sale", Month = "may", EmployeeSalary =450000, SalaryId = 101, StartDate=new DateTime(2020, 01, 04), Gender = 'M',DepartmentId=3,CompanyId=2,isEmployeeActive=true});
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 13, EmployeeName = "suraj", JobDescription = "hr", Month = "nov", EmployeeSalary = 550000, SalaryId = 102, StartDate = new DateTime(2020, 02, 04), Gender = 'M', DepartmentId = 3, CompanyId = 2 ,isEmployeeActive=true});
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 3, EmployeeName = "summet", JobDescription = "sale", Month = "dec", EmployeeSalary = 650000, SalaryId = 103, StartDate = new DateTime(2022, 01, 04), Gender = 'M', DepartmentId = 2, CompanyId = 2,isEmployeeActive=true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 4, EmployeeName = "dharma", JobDescription = "Sale", Month = "oct", EmployeeSalary = 750000, SalaryId = 104, StartDate = new DateTime(2021, 01, 04), Gender = 'M', DepartmentId = 2, CompanyId = 3,isEmployeeActive=true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 5, EmployeeName = "prem", JobDescription = "hr", Month = "apr", EmployeeSalary = 850000, SalaryId = 105, StartDate = new DateTime(2018, 01, 04), Gender = 'M', DepartmentId = 3, CompanyId = 2,isEmployeeActive=true });

            EmployeePayrollOperation employeePayroll = new EmployeePayrollOperation();
            DateTime startTime = DateTime.Now;
            employeePayroll.addEmployeeToPayroll(emploeeModellist);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Durations without the thread = " + (endTime - startTime));
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeId = 109,
                EmployeeName = "amol",
                JobDescription = "Hr",
                Month = "oct",
                EmployeeSalary = 77000,
                SalaryId = 101,
                StartDate = new DateTime(2018, 02, 22),
                Gender = 'M',
                DepartmentId = 3,
                CompanyId = 2,
                isEmployeeActive = true
            };
            DateTime startTimeForDb = DateTime.Now;
            employeePayrollRepo.addEmployee(employeeModel);
            DateTime endTimeForDb = DateTime.Now;
            Console.WriteLine("Durations without the thread = " + (startTimeForDb - endTimeForDb));
           
            DateTime startTimeWithThread = DateTime.Now;
            employeePayroll.addEmployeeToPayrollWithThread(emploeeModellist);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Durations with the thread = " + (startTimeWithThread - endTimeWithThread));
        }
       
        /// <summary>
        ///given list and db when insert in payroll table then calculate execution time
        /// </summary>
        [TestMethod]
        public void givenListAndDb_WhenInsertInPayrollTable_ThenCalculateExacutionTime()
        {
            List<EmployeeModel> emploeeModellist = new List<EmployeeModel>();
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 1, EmployeeName = "Dhiraj", JobDescription = "Sale", Month = "may", EmployeeSalary = 450000, SalaryId = 101, StartDate = new DateTime(2020, 01, 04), Gender = 'M', DepartmentId = 3, CompanyId = 2, isEmployeeActive = true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 2, EmployeeName = "suraj", JobDescription = "hr", Month = "nov", EmployeeSalary = 550000, SalaryId = 102, StartDate = new DateTime(2020, 02, 04), Gender = 'M', DepartmentId = 3, CompanyId = 2, isEmployeeActive = true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 8, EmployeeName = "summet", JobDescription = "sale", Month = "dec", EmployeeSalary = 650000, SalaryId = 103, StartDate = new DateTime(2022, 01, 04), Gender = 'M', DepartmentId = 2, CompanyId = 2, isEmployeeActive = true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 6, EmployeeName = "dharma", JobDescription = "Sale", Month = "oct", EmployeeSalary = 750000, SalaryId = 104, StartDate = new DateTime(2021, 01, 04), Gender = 'M', DepartmentId = 2, CompanyId = 3, isEmployeeActive = true });
            emploeeModellist.Add(new EmployeeModel() { EmployeeId = 9, EmployeeName = "prem", JobDescription = "hr", Month = "apr", EmployeeSalary = 850000, SalaryId = 105, StartDate = new DateTime(2018, 01, 04), Gender = 'M', DepartmentId = 3, CompanyId = 2, isEmployeeActive = true });

            EmployeePayrollOperation employeePayroll = new EmployeePayrollOperation();
            DateTime startTime = DateTime.Now;
            employeePayroll.addEmployeeToPayroll(emploeeModellist);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Durations without the thread = " + (endTime - startTime));
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeId = 107,
                EmployeeName = "dhiraj",
                JobDescription = "Hr",
                Month = "may",
                EmployeeSalary = 77000,
                SalaryId = 101,
                StartDate = new DateTime(2019, 02, 22),
                Gender = 'M',
                DepartmentId = 3,
                CompanyId = 2,
                isEmployeeActive = true
            };
            
            DateTime startTimesForDb = DateTime.Now;
            employeePayrollRepo.addEmployeeToPayroll(employeeModel);
            DateTime endTimesForDb = DateTime.Now;
            Console.WriteLine("Duration for insertion in payroll = " + (startTimesForDb - endTimesForDb));

            DateTime startTimeWithThread = DateTime.Now;
            employeePayroll.addEmployeeToPayrollWithThread(emploeeModellist);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Durations with the thread = " + (startTimeWithThread - endTimeWithThread));
        }
        
        /// <summary>
        /// given data base when update then calculate execution time.
        /// </summary>
        [TestMethod]
        public void givenDb_WhenUpdateSalary_ThenCalaculateExecutionTime()
        {
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
               EmployeeName="Prem",
               EmployeeSalary=65000
            };

            DateTime startTimesForDb = DateTime.Now;
            employeePayrollRepo.updateEmployeeSalary(employeeModel);
            DateTime endTimesForDb = DateTime.Now;
            Console.WriteLine("Durations for updation in data base = " + (startTimesForDb - endTimesForDb));
        }
    }
}

