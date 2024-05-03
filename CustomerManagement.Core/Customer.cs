using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.Core
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
