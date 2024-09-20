using Dapper;
using PinewoodTechAPI.DTOs;
using PinewoodTechAPI.Interfaces;
using PinewoodTechTaskAPI.Interfaces;
using System.Data;

namespace PinewoodTechTaskAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbConnection _dbConnection;
        public CustomerService(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection;
        }

        public async Task<object> GetCustomer(int id)
        {
            _dbConnection.Open();
            using (IDbTransaction transaction = _dbConnection.BeginTransaction())
            {
                DynamicParameters dyn = new DynamicParameters();
                dyn.Add("id", id);
                string sql = $"SELECT * FROM dbo.Customers WHERE Id = @id"; 
                try
                {
                    var result = await transaction.Connection.QuerySingleAsync<CustomerDTO>(sql: sql,dyn, transaction: transaction);

                    return result;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
                finally 
                {
                    _dbConnection.Close();
                }
            }
        }

        public async Task<object> GetCustomers()
        {
            _dbConnection.Open();
            using(IDbTransaction transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    const string sql = $"SELECT * FROM dbo.Customers;";
                    var result = await transaction.Connection.QueryAsync<CustomerDTO>(sql, transaction: transaction);

                    return result.ToList();

                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

        }

        public async Task<object> PutCustomer(int id, ICustomerDTO updateCustomer)
        {
            _dbConnection.Open();
            using (IDbTransaction transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    DynamicParameters dyn = new DynamicParameters();

                    dyn.Add("id", id);
                    dyn.Add("firstName", updateCustomer.FirstName);
                    dyn.Add("lastName", updateCustomer.LastName);
                    dyn.Add("email", updateCustomer.Email);
                    dyn.Add("phone", updateCustomer.PhoneNumber);
                    dyn.Add("address", updateCustomer.Address);
                    dyn.Add("city", updateCustomer.City);
                    dyn.Add("region", updateCustomer.Region);
                    dyn.Add("country", updateCustomer.Country);

                    string sql = $"UPDATE dbo.Customers SET " +
                        $"FirstName = @firstName , LastName = @lastName, Email = @email," +
                        $"PhoneNumber = @phone, Address = @address, city = @city," +
                        $"region= @region, Country = @country " +
                        $"WHERE Id = @id;";
                    var result = await transaction.Connection.ExecuteAsync(sql, dyn, transaction: transaction);

                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message.ToString();
                }
                finally
                {
                    _dbConnection.Close();
                }
            }
            
        }

        public async Task<object> PostCustomer(ICustomerDTO newCustomer)
        {
            _dbConnection.Open();
            using (IDbTransaction transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    DynamicParameters dyn = new DynamicParameters();

                    dyn.Add("customerId", newCustomer.CustomerId);
                    dyn.Add("firstName", newCustomer.FirstName);
                    dyn.Add("lastName", newCustomer.LastName);
                    dyn.Add("email", newCustomer.Email);
                    dyn.Add("phone", newCustomer.PhoneNumber);
                    dyn.Add("address", newCustomer.Address);
                    dyn.Add("city", newCustomer.City);
                    dyn.Add("region", newCustomer.Region);
                    dyn.Add("country", newCustomer.Country);

                    string sql = $"INSERT INTO dbo.Customers " +
                        $"(CustomerId, FirstName, LastName, Email, PhoneNumber, Address, city, region, Country) " +
                        $"Values(@customerId, @firstName , @lastName, @email, @phone, @address, @city, @region, @country);";
                    var result = await transaction.Connection.ExecuteAsync(sql, dyn, transaction);

                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message.ToString();
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

        }

        public async Task<object> DeleteCustomer(int id)
        {
            _dbConnection.Open();
            using (IDbTransaction transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    DynamicParameters dyn = new DynamicParameters();
                    dyn.Add("id", id);

                    string sql = $"DELETE FROM dbo.Customers WHERE CustomerId = @id";
                    var result = await transaction.Connection.ExecuteAsync(sql, dyn, transaction);

                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message.ToString();
                }
                finally
                {
                    _dbConnection.Close();
                }
            }
        }
    }
}
