using CustomerManagement.Core;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infra
{
    public class CustomerManagementDBContext : DbContext
    {
        public CustomerManagementDBContext(DbContextOptions<CustomerManagementDBContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
