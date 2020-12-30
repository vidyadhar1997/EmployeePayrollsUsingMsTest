using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePyrolls
{
    public class EmployeePayrollRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void checkConnection()
        {
            try
            {
                this.sqlConnection.Open();
                Console.WriteLine("connection established");
                this.sqlConnection.Close();
            }
            catch
            {
                Console.WriteLine("not established");
            }
        }
    }
}
