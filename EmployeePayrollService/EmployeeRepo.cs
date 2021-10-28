using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString); 

        public void GetAllEmployees()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string Query = @"SELECT * FROM Employee_Payroll;";

                    SqlCommand command = new SqlCommand(Query, this.sqlConnection);
                    this.sqlConnection.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    if(dataReader.HasRows)
                    {
                        while(dataReader.Read())
                        {
                            model.Id = dataReader.GetInt32(0);
                            model.EmpName = dataReader.GetString(1);
                            model.BasicPay = dataReader.GetDecimal(2);
                            model.StartDate = dataReader.GetDateTime(3);
                            model.Gender = dataReader.GetString(4);
                            model.PhoneNumber = dataReader.GetString(5);
                            model.Department = dataReader.GetString(6);
                            model.Address = dataReader.GetString(7);
                            model.Deduction = dataReader.GetFloat(8);
                            model.TaxablePay = dataReader.GetDecimal(9);
                            model.IncomeTax = dataReader.GetDecimal(10);
                            model.NetPay = dataReader.GetDouble(11);
                            Console.WriteLine(model.Id + " " + model.EmpName + " " + model.BasicPay + " " + model.StartDate + " " + model.Gender + " " +
                                              model.PhoneNumber + " " + model.Department + " " + model.Address + " " + model.Deduction + " " +
                                              model.TaxablePay + " " + model.IncomeTax + " " + model.IncomeTax + " " + model.NetPay + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found!");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@EmpName", model.EmpName);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);

                    this.sqlConnection.Open();
                    var Result = command.ExecuteNonQuery();
                    this.sqlConnection.Close();

                    if(Result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return false;
        }
    }
}
