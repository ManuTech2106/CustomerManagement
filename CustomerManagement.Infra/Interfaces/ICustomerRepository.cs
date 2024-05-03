using CustomerManagement.Core;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infra.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByID(Guid customerId);
        Task<Guid> CreateCustomer(Customer customer);
        Task<Guid> DeleteCustomer(Guid customerID);
        Task<Customer> UpdateCustomer(Customer customer);
        Task PatchCustomer(Guid customerId, JsonPatchDocument customerToUpdate);
        Task<object> Save();
    }
}
