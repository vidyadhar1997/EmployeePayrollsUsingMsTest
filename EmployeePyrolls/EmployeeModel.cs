﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePyrolls
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string Month { get; set; }
        public int EmployeeSalary { get; set; }
        public int SalaryId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
