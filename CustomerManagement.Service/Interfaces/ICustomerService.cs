using CustomerManagement.Core;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetById(Guid id);
        Task<IEnumerable<Customer>> GetCustomersByAge(int Age);
        Task<Guid> CreateCustomer(Customer customer);
        Task UpdateCustomer(int id, Customer customer);
        Task<Guid> DeleteCustomer(int customerId);
        Task PatchCustomer(Guid customerId, JsonPatchDocument customerToUpdate);
    }
}