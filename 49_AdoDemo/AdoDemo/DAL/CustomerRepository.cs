using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo
{
    class CustomerRepository : ICustomerRepository
    {
        private string _sqlConnectionString;
        public CustomerRepository(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public Customer Create(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                string sql = @"INSERT INTO Customer (FirstName, LastName, EmailAddress, Phone, [Address], City, Province, PostalCode, CustomerSince) "
                    + "VALUES(@FirstName,@LastName,@EmailAddress,@Phone,@Address,@City,@Province,@PostalCode,@CustomerSince)";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                    command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(customer.Phone) ? DBNull.Value : customer.Phone);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Province", customer.Province);
                    command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                    command.Parameters.AddWithValue("@CustomerSince", customer.CustomerSince);
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
            return customer;
        }

        public void Delete(int customerId)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                var deleteSqlOne = "DELETE [Login] WHERE CustomerId = @CustomerId;";
                var deleteSqlTwo = "DELETE ProjectItem WHERE  ProjectItem.ProjectId = (SELECT ProjectId FROM Project WHERE Project.CustomerId = @CustomerId);";
                var deleteSqlThree = "DELETE ProjectEmployee WHERE ProjectEmployee.ProjectId = (SELECT ProjectId FROM Project WHERE Project.CustomerId = @CustomerId);";
                var deleteSqlFour = "DELETE Project WHERE CustomerId = @CustomerId;";
                var deleteSqlFive = "DELETE Customer WHERE CustomerId = @CustomerId;";

                var deleteCommandOne = new SqlCommand(deleteSqlOne, connection);
                deleteCommandOne.Parameters.AddWithValue("@CustomerId", customerId);
                var deleteCommandTwo = new SqlCommand(deleteSqlTwo, connection);
                deleteCommandTwo.Parameters.AddWithValue("@CustomerId", customerId);
                var deleteCommandThree = new SqlCommand(deleteSqlThree, connection);
                deleteCommandThree.Parameters.AddWithValue("@CustomerId", customerId);
                var deleteCommandFour = new SqlCommand(deleteSqlFour, connection);
                deleteCommandFour.Parameters.AddWithValue("@CustomerId", customerId);
                var deleteCommandFive = new SqlCommand(deleteSqlFive, connection);
                deleteCommandFive.Parameters.AddWithValue("@CustomerId", customerId);

                try
                {
                    connection.Open();

                    deleteCommandOne.ExecuteNonQuery();
                    deleteCommandTwo.ExecuteNonQuery();
                    deleteCommandThree.ExecuteNonQuery();
                    deleteCommandFour.ExecuteNonQuery();
                    deleteCommandFive.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!" + ex.Message);
                }
            }
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
            {
                string sql = @"SELECT CustomerId, FirstName, LastName, EmailAddress, Phone, [Address], City, Province, PostalCode, CustomerSince FROM Customer;";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.HasRows && dr.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = int.Parse(dr["CustomerId"].ToString());
                        customer.FirstName = dr["FirstName"].ToString();
                        customer.LastName = dr["LastName"].ToString();
                        customer.EmailAddress = dr["EmailAddress"].ToString();
                        customer.EmailAddress = dr["Phone"] is DBNull ? "" : dr["Phone"].ToString();
                        customer.EmailAddress = dr["Address"].ToString();
                        customer.EmailAddress = dr["City"].ToString();
                        customer.EmailAddress = dr["Province"].ToString();
                        customer.EmailAddress = dr["PostalCode"].ToString();
                        customer.CustomerSince = DateTime.Parse(dr["CustomerSince"].ToString());

                        customers.Add(customer);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error!" + ex.Message);
                }
            }
            return customers;
        }

        public void Update(Customer customer)
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                var updateSql = "UPDATE Customer "
                    + "SET FirstName = @FirstName, "
                    + "LastName = @LastName, "
                    + "EmailAddress = @EmailAddress, "
                    + "Phone = @Phone, "
                    + "[Address] = @Address, "
                    + "City = @City, "
                    + "Province = @Province, "
                    + "PostalCode = @PostalCode, "
                    + "CustomerSince = @CustomerSince "
                    + "WHERE CustomerId = @CustomerId;";

                var updateCommand = new SqlCommand(updateSql, connection);
                updateCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                updateCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                updateCommand.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                updateCommand.Parameters.AddWithValue("@Phone", customer.Phone);
                updateCommand.Parameters.AddWithValue("@Address", customer.Address);
                updateCommand.Parameters.AddWithValue("@City", customer.City);
                updateCommand.Parameters.AddWithValue("@Province", customer.Province);
                updateCommand.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                updateCommand.Parameters.AddWithValue("@CustomerSince", customer.CustomerSince);

                updateCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerId);

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
