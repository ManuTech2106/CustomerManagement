using CustomerManagement.Core;
using CustomerManagement.Infra.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private CustomerManagementDBContext _context;

        public CustomerRepository(CustomerManagementDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByID(Guid id)
        {
           var result =  await _context.Customers.FindAsync(id);
           return result;
        }

        public async Task<Guid> CreateCustomer(Customer Customer)
        {
            await _context.Customers.AddAsync(Customer);
            await _context.SaveChangesAsync();
            return Customer.CustomerId;
        }

        public async Task<Guid> DeleteCustomer(Guid customerID)
        {
            var customer = await GetCustomerByID(customerID);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                return customerID;
            }
            else
            { 
               return Guid.Empty;
            }
        }


        public async Task PatchCustomer(Guid customerId, JsonPatchDocument customerToUpdate)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (customer != null)
            {
                customerToUpdate.ApplyTo(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
            //    var cust = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
            //    var result = await _context.Customers.Update(cust);
            //    return result;
         }

        //Task<object> ICustomerRepository.Save()
        //{
        //    throw new NotImplementedException();
        //}


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        public Task<object> Save()
        {
            throw new NotImplementedException();
        }
    }
}
