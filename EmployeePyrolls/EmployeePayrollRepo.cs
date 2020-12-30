﻿using System;
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
                            employeeModel.StartDate = sqlDataReader.GetDateTime(6);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.JobDescription, employeeModel.Month, employeeModel.EmployeeSalary, employeeModel.SalaryId, employeeModel.StartDate);
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
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int updateEmployee()
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
        }

        /// <summary>
        /// Gets the employee data with given range.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getEmployeeDataWithGivenRange()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select count(EmployeeName) from EmplyeePayroll where StartDate between cast('2010-01-01' as date) and CAST('2020-01-01' as date)";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
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
        }

        /// <summary>
        /// Gets the aggrigate sum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAggrigateSumSalary()
        {
            try
            {
                int sum = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select sum(EmployeeSalary) from  EmplyeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            sum = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return sum;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the aggrigate sum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAvragSalary()
        {
            try
            {
                int avg = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select avg(EmployeeSalary) from  EmplyeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            avg = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return avg;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the minimum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getMinSalary()
        {
            try
            {
                int min = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select min(EmployeeSalary) from  EmplyeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            min = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return min;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the maximum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getMaxSalary()
        {
            try
            {
                int max = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select max(EmployeeSalary) from  EmplyeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            max = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return max;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// Gets the maximum salary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getCountSalary()
        {
            try
            {
                int count = 0;
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"select count(EmployeeSalary) from  EmplyeePayroll GROUP BY gender;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
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
        }
    }
}
