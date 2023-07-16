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
    }
}
