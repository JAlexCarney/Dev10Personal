using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _sqlConnectionString;
        public EmployeeRepository(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public Employee Create(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnectionString))
            {
                string sql = @"INSERT INTO Employee (firstName,lastName,startDate,endDate) values(@firstName,@lastName,@startDate,@endDate)";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@firstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", employee.EndDate);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
            return employee;
        }

        public void Delete(int employeeId)
        {
            using (var connection = new SqlConnection(_sqlConnectionString)) 
            {
                var deleteSqlOne = "DELETE ProjectEmployee WHERE EmployeeId = @EmployeeId;";
                var deleteSqlTwo = "DELETE Employee WHERE EmployeeId = @EmployeeId;";

                var deleteCommandOne = new SqlCommand(deleteSqlOne, connection);
                deleteCommandOne.Parameters.AddWithValue("@EmployeeId", employeeId);
                var deleteCommandTwo = new SqlCommand(deleteSqlTwo, connection);
                deleteCommandTwo.Parameters.AddWithValue("@EmployeeId", employeeId);

                try
                {
                    connection.Open();

                    deleteCommandOne.ExecuteNonQuery();
                    deleteCommandTwo.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
        }

        public List<Employee> ReadAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(_sqlConnectionString))
            {
                string sql = @"select EmployeeId, FirstName, LastName, StartDate, EndDate From Employee";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.HasRows && dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = int.Parse(dr["employeeId"].ToString());
                        employee.FirstName = dr["FirstName"].ToString();
                        employee.LastName = dr["LastName"].ToString();
                        employee.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                        employee.EndDate = dr["EndDate"] is DBNull ? null : DateTime.Parse(dr["EndDate"].ToString());

                        employees.Add(employee);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error!" + ex.Message);
                }
                finally
                {
                    if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return employees;

        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                var updateSql = "UPDATE Employee "
                    + "SET FirstName = @FirstName, "
                    + "LastName = @LastName, "
                    + "StartDate = @StartDate, "
                    + "EndDate = @EndDate "
                    + "WHERE EmployeeId = @EmployeeId;";

                var updateCommand = new SqlCommand(updateSql, connection);
                updateCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                updateCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                updateCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                updateCommand.Parameters.AddWithValue("@EndDate", employee.EndDate);
                updateCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);

                try
                {
                    connection.Open();

                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
        }
    }
}
