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
        [TestMethod]
        public void TestMethod1()
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
            Console.WriteLine("Duration without thread = " + (endTime - startTime));
            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeId = 81,
                EmployeeName = "dhiraj",
                JobDescription = "hr",
                Month = "may",
                EmployeeSalary = 67000,
                SalaryId = 101,
                StartDate = new DateTime(2019, 02, 22),
                DepartmentId = 3,
                CompanyId = 2,
                isEmployeeActive = true

            };
            DateTime startTimes = DateTime.Now;
            employeePayrollRepo.addEmployee(employeeModel);
            DateTime endTimes = DateTime.Now;
            Console.WriteLine("Duration without thread = " + (endTimes - startTimes));

        }
    }
}
