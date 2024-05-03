using CustomerManagement.API.Controllers;
using CustomerManagement.Service.Interfaces;
using CustomerManagement.Core;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Test.Controllers
{
    public class CustomerTest
    {

        private Mock<ICustomerService> _customerServiceMock;
        private CustomersController _customersController;

        List<Customer> customerData = new List<Customer>();


        public CustomerTest()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _customersController = new CustomersController(_customerServiceMock.Object);
            this.SetupData();
        }

        internal void SetupData()
        {
            Customer c1 = new Customer()
            {
                CustomerId = new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"),
                FullName = "John A",
                DateOfBirth = new DateOnly(2023, 05, 03),
            };
            customerData.Add(c1);

            Customer c2 = new Customer()
            {
                CustomerId = new Guid("016203c2-4c32-464e-b9c0-440c05563243"),
                FullName = "John B",
                DateOfBirth = new DateOnly(2022, 05, 03),
            };
            customerData.Add(c2);


            Customer c3 = new Customer()
            {
                CustomerId = new Guid("192e8c3b-f40d-4cdc-9f3c-cf59fbd3e191"),
                FullName = "John C",
                DateOfBirth = new DateOnly(2021, 05, 03),
            };
            customerData.Add(c3);
        }


        [Fact]
        public void Test_GetCustomers_Should_Return_OkResult_And_ShouldNotBeNull()
        {
            //Arrange
            _customerServiceMock.Setup<Task<IEnumerable<Customer>>>(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(customerData));

            //Act
            var objCustomer = _customersController.GetCustomers();
            var result = objCustomer.Result;
        
            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        [Fact]
        public void Test_GetCustomers_Should_Return_NotFoundResult()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(null));
            var customResponse = new { message = "Customers are not available." };

            //Act
            var objCustomer = _customersController.GetCustomers();
            var result = objCustomer.Result;

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            //var value = ((NotFoundObjectResult)result).Value;
        }


        [Fact]
        public void Test_GetCustomerById_Should_Return_OkResult_And_ShouldNotBeNull()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.GetById(new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"))).Returns(Task.FromResult<Customer>(new Customer () {CustomerId = new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"), FullName = "John", DateOfBirth = new DateOnly(2023, 05, 03) }));

            //Act
            var result = _customersController.GetCustomerById(new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"));

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        [Fact]
        public void Test_GetCustomerById_Should_Return_NotFoundResult()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(null));

            //Act
            var result = _customersController.GetCustomerById(It.IsAny<Guid>());

            //Assert
            result.Result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Test_GetCustomerByAge_Should_Return_OkResult_And_ShouldNotBeNull()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.GetCustomersByAge(1)).Returns(Task.FromResult<IEnumerable<Customer>>(customerData));

            //Act
            var result = _customersController.GetCustomerByAge(1);

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
        }

        [Fact]
        public void Test_GetCustomerByAge_Should_Return_NotFoundResult()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.GetCustomersByAge(1)).Returns(Task.FromResult<IEnumerable<Customer>>(null));
            //var customResponse = new { message = "Customers are not available." };

            //Act
            var objCustomer = _customersController.GetCustomerByAge(1);
            var result = objCustomer.Result;

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            //var value = ((NotFoundObjectResult)result).Value;
        }

        [Fact]
        public void Test_CreateCustomer_Should_Return_CreatedAtActionResult_And_ShouldNotBeNull()
        {
            //Arrange
            _customerServiceMock.Setup(x => x.CreateCustomer(new Customer() { CustomerId = new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"), FullName = "John", DateOfBirth = new DateOnly(2023, 05, 03) })).Returns(Task.FromResult<Guid>(new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2")));

            //Act
            var result = _customersController.CreateCustomer (new Customer() { CustomerId = new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"), FullName = "John", DateOfBirth = new DateOnly(2023, 05, 03) });

            //Assert
            result.Result.Should().BeOfType<CreatedAtActionResult>();
            result.Should().NotBeNull();
        }
    }
}