using CustomerManagement.Core;
using CustomerManagement.Infra.Interfaces;
using CustomerManagement.Service.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CustomerManagement.Service.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        //private readonly IUnitOfWork _unitOfWork;


        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
            //this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Customers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetById(Guid id)
        {
            return await _customerRepository.GetCustomerByID(id);
        }

        /// <summary>
        /// Get customer by Age.
        /// </summary>
        /// <param name="Age"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomersByAge(int Age)
        {
            var customers =  await _customerRepository.GetCustomers();

            // Save today's date.
            var today = DateTime.Today;

            var maxAge = DateOnly.FromDateTime(today.AddYears(-Age));

            var result = customers.Where(x => x.DateOfBirth == maxAge);
            return result;
        }

        /// <summary>
        /// Patch customer details.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
        public async Task PatchCustomer(Guid customerId, JsonPatchDocument customerToUpdate)
        {
            await _customerRepository.PatchCustomer(customerId, customerToUpdate);
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Guid> CreateCustomer(Customer customer)
        {
            var result =  await _customerRepository.CreateCustomer(customer);
            return result;
        }

        /// <summary>
        /// Not Implemented Delete Operation, not required as per of requirement.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Guid> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented Updated operation as it is not required as per of requirement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
