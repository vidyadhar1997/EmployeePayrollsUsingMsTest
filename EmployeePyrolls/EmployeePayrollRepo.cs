using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePyrolls
{
    public class EmployeePayrollRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        /// <summary>
        /// Checks the connection.
        /// </summary>
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

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAllEmployee()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateEmplyeeSalary", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            employeeModel.EmployeeId = sqlDataReader.GetInt32(0);
                            employeeModel.EmployeeName = sqlDataReader.GetString(1);
                            employeeModel.JobDescription = sqlDataReader.GetString(2);
                            employeeModel.Month = sqlDataReader.GetString(3);
                            employeeModel.EmployeeSalary = sqlDataReader.GetInt32(4);
                            employeeModel.SalaryId = sqlDataReader.GetInt32(5);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.JobDescription, employeeModel.Month, employeeModel.EmployeeSalary, employeeModel.SalaryId);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return count;
            }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int addEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                using (this.sqlConnection)
                {
                    string query = @"update EmplyeePayroll set employeeSalary=3000000 where EmployeeName='dhiraj';";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        query = @"Select employeeSalary from EmplyeePayroll where EmployeeName='dhiraj';";
                        cmd = new SqlCommand(query, sqlConnection);
                        object res = cmd.ExecuteScalar();
                        sqlConnection.Close();
                        employeeModel.EmployeeSalary = (int)res;
                        return (employeeModel.EmployeeSalary);
                    }
                    else
                    {
                        sqlConnection.Close();
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
