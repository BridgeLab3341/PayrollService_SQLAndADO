using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSerivce_SQLAndADO
{
    public class PayRollOperation
    {
        public static string connectionString = "data source=(localdb)\\MSSQLLocalDB; initial catalog=PayRollService";
        SqlConnection sqlConne = new SqlConnection(connectionString);
        public static void CreateDatabase()
        {
            SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            try
            {
                string query = "Create Database PayRollService";
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                sql.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong"+ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public static SqlConnection connection= new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog=PayRollService; integrated security=true");
        public static void RetrieveAllEmployeePayRollRecords()
        {
            try
            {
                using (connection)
                {
                    EmployeeData employee = new EmployeeData();
                    string query = "Select * from Employee_PayRoll";
                    SqlCommand sql = new SqlCommand(query, connection);
                    sql.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            employee.Id = reader.GetInt32(0);
                            employee.Name = reader.GetString(1);
                            employee.Salary = reader.GetInt64(2);
                            employee.StartDate = reader.GetDateTime(3);
                            employee.Gender = reader.GetChar(4);
                            employee.Phone = reader.GetString(5);
                            employee.Address = reader.GetString(6);
                            employee.Department = reader.GetString(7);
                            employee.BasicPay = reader.GetInt64(8);
                            employee.Deductions = reader.GetInt64(9);
                            employee.TaxablePay = reader.GetInt64(10);
                            employee.IncomeTax = reader.GetInt64(11);
                            employee.NetPay = reader.GetInt64(12);
                        }
                        Console.WriteLine(employee.Id + "\n" + employee.Name + "\n" + employee.Salary + "\n" + employee.StartDate + "\n" + employee.Gender + "\n" + employee.Phone + "\n" + employee.Address +
                        "\n" + employee.Department + "\n" + employee.BasicPay + "\n" + employee.Deductions + "\n" + employee.TaxablePay + "\n" + employee.IncomeTax + "\n" + employee.NetPay);
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("something Went Wrong"+ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void UpdateTheSalary()
        {
            try
            {
                string query = "Update Employee_PayRoll set Salary=3000000 where Id=14";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Update Record Successfully");
                Console.WriteLine("----------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Somrthing Went Wrong "+ex);
            }
        }
        public  void UpdateSalaryByConnectingString(int id,double basicPay)
        {
            try
            {
                using(this.sqlConne)
                {
                    SqlCommand command = new SqlCommand("UpdateSalary", this.sqlConne);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@BasicPay",basicPay);
                    this.sqlConne.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    this.sqlConne.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("BasicPay Updated Succssefully");
                    else
                    {
                        Console.WriteLine("BasicPay Updated UnSuccssefully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetDataInParticularRange(DateTime fromDate,DateTime toDate)
        {
            EmployeeData employee= new EmployeeData();
            try
            {
                using (this.sqlConne)
                {
                    string query = "Select * from Employee_PayRoll ";
                    SqlCommand command = new SqlCommand(query, this.sqlConne);
                    command.CommandType = System.Data.CommandType.Text;
                    this.sqlConne.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee.Id = reader.GetInt32(0);
                            employee.Name = reader.GetString(1);
                            employee.Salary = reader.GetInt64(2);
                            employee.StartDate = reader.GetDateTime(3);
                            employee.Gender = reader.GetChar(4);
                            employee.Phone = reader.GetString(5);
                            employee.Address = reader.GetString(6);
                            employee.Department = reader.GetString(7);
                            employee.BasicPay = reader.GetInt64(8);
                            employee.Deductions = reader.GetInt64(9);
                            employee.TaxablePay = reader.GetInt64(10);
                            employee.IncomeTax = reader.GetInt64(11);
                            employee.NetPay = reader.GetInt64(12);
                        }
                        Console.WriteLine(employee.Id + "\n" + employee.Name + "\n" + employee.Salary + "\n" + employee.StartDate + "\n" + employee.Gender + "\n" + employee.Phone + "\n" + employee.Address +
                        "\n" + employee.Department + "\n" + employee.BasicPay + "\n" + employee.Deductions + "\n" + employee.TaxablePay + "\n" + employee.IncomeTax + "\n" + employee.NetPay);
                    }
                    else
                    {
                        Console.WriteLine("No Records Found ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong"+ex);
            }
        }
        public void AbilityToFindOperation()
        {
            EmployeeData employee = new EmployeeData();
            try
            {
                using(this.sqlConne)
                {
                    connection.Open();
                    //Sum of Salary for Females
                    string sumQuery = "Select sum(Salary) as TotalSalary from Employee_PayRoll where Gender='F' Group by Gender";
                    SqlCommand command = new SqlCommand(sumQuery, this.sqlConne);
                    long sumOfSalaryFemale = Convert.ToInt64(command.ExecuteScalar());
                    //Average Salary for Females
                    String AvgQuery = "Select AVG(Salary) as AverageSalary from Employee_PayRoll where Gender='F' Group by Gender";
                    SqlCommand command1 = new SqlCommand(AvgQuery, this.sqlConne);
                    decimal avgSalaryFemale = Convert.ToDecimal(command1.ExecuteScalar());
                    // Calculate minimum salary for females
                    string minQuery = "SELECT MIN(salary) FROM employee_payroll WHERE gender = 'F'";
                    SqlCommand minCommand = new SqlCommand(minQuery, connection);
                    long minSalaryFemale = Convert.ToInt64(minCommand.ExecuteScalar());
                    // Calculate maximum salary for females
                    string maxQuery = "SELECT MAX(salary) FROM employee_payroll WHERE gender = 'F'";
                    SqlCommand maxCommand = new SqlCommand(maxQuery, connection);
                    long maxSalaryFemale = Convert.ToInt64(maxCommand.ExecuteScalar());
                    // Count the number of female employees
                    string countQuery = "SELECT COUNT(*) FROM employee_payroll WHERE gender = 'F'";
                    SqlCommand countCommand = new SqlCommand(countQuery, connection);
                    int countFemale = Convert.ToInt32(countCommand.ExecuteScalar());
                    // Count the number of male employees
                    string countMaleQuery = "SELECT COUNT(*) FROM employee_payroll WHERE gender = 'M'";
                    SqlCommand countMaleCommand = new SqlCommand(countMaleQuery, connection);
                    int countMale = Convert.ToInt32(countMaleCommand.ExecuteScalar());
                    Console.WriteLine("Sum of salary of females is: " + sumOfSalaryFemale);
                    Console.WriteLine("Average salary of females is: " + avgSalaryFemale);
                    Console.WriteLine("Minimum salary of females is: " + minSalaryFemale);
                    Console.WriteLine("Maximum salary of females is: " + maxSalaryFemale);
                    Console.WriteLine("Number of female employees: " + countFemale);
                    Console.WriteLine("Number of male employees: " + countMale);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong"+ex);
            }
        }
        public void AddEmployee(EmployeeData employee)
        {
            try
            {
                using(this.sqlConne)
                {
                    SqlCommand cmd = new SqlCommand("AddEmployee",this.sqlConne);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StarDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    cmd.Parameters.AddWithValue("@Deductions", employee.Deductions);
                    cmd.Parameters.AddWithValue("@TaxablePay", employee.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    this.sqlConne.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Employee Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Employee Added UnSuccessfully");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        List<long> employeeSalary = new List<long>();
        public void AddPayRoll()
        {
            EmployeeData employee = new EmployeeData();
            int a = 1;
            RetrieveAllEmployeePayRollRecords();
            using (this.sqlConne)
            {

                SqlCommand command = new SqlCommand("AddPayRoll", this.sqlConne);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var item in employeeSalary)
                {

                    employee.Deductions = (item * 20 / 100);
                    employee.TaxablePay = item - employee.Deductions;
                    employee.IncomeTax = employee.TaxablePay * 10 / 100;
                    employee.NetPay = item - employee.IncomeTax;
                    command.Parameters.AddWithValue("@Deductions", employee.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", employee.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", employee.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", employee.NetPay);
                    command.Parameters.AddWithValue("@EmpID", a);
                    a++;

                }

                this.sqlConne.Open();
                var result1 = command.ExecuteNonQuery();
                this.sqlConne.Close();
                if (result1 != 0)
                {
                    Console.WriteLine("Payroll Added Successfully");
                }
                else
                {
                    Console.WriteLine("Payroll Added UnSuccessfully");
                }

            }
        }
    }
}
