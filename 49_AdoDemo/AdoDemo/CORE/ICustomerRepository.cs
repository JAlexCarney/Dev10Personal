using System.Collections.Generic;

namespace AdoDemo
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        List<Customer> ReadAll();
        void Update(Customer customer);
        void Delete(int customerId);
    }
}