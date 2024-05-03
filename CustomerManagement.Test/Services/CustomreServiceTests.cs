using CustomerManagement.Service.Interfaces;
using CustomerManagement.Core;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using CustomerManagement.API.Controllers;
using CustomerManagement.Infra.Interfaces;
using CustomerManagement.Service.Implementation;

namespace CustomerManagement.Test.Services
{
    public class CustomreServiceTests
    {

        private Mock<ICustomerRepository> _customerRepositoryMock;
        private CustomerService _customerService;

        List<Customer> customerData = new List<Customer>();


        public CustomreServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
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
        public void Test_GetCustomer_Should_Not_Return_Empty_Result()
        {
             //Arrange
            _customerRepositoryMock.Setup<Task<IEnumerable<Customer>>>(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(customerData));

            //Act
            var objCustomer = _customerService.GetCustomers();
            var result = objCustomer.Result;

            //Assert
            result.Should().NotBeEmpty();  

        }

        [Fact]
        public void Test_GetCustomer_Should_Return_Empty_Result()
        {
             //Arrange
            _customerRepositoryMock.Setup<Task<IEnumerable<Customer>>>(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(null));

            //Act
            var objCustomer = _customerService.GetCustomers();
            var result = objCustomer.Result;

            //Assert
            result.Should().BeNullOrEmpty();

        }


        [Fact]
        public void Test_GetById_Should_Not_Return_Empty_Result()
        {
            //Arrange
            _customerRepositoryMock.Setup(x => x.GetCustomerByID(new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"))).Returns(Task.FromResult<Customer>(new Customer() { CustomerId = new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"), FullName = "John", DateOfBirth = new DateOnly(2023, 05, 03) }));

            //Act
            var objCusrtomer = _customerService.GetById(new Guid("1f42155e-3a29-45db-88df-df3d6b98a3a2"));
            var result = objCusrtomer.Result;

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void Test_GetCustomerById_Should_Return_NotFoundResult()
        {
            //Arrange
            _customerRepositoryMock.Setup(x => x.GetCustomerByID(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(null));

            //Act
            var objCustomer = _customerService.GetById(It.IsAny<Guid>());
            var result = objCustomer.Result;

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Test_GetCustomerByAge_Should_Not_Return_Empty_Result_When_Matching()
        {
            //Arrange
            _customerRepositoryMock.Setup<Task<IEnumerable<Customer>>>(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(customerData));

            //Act
            var result = _customerService.GetCustomersByAge(1);

            //Assert
             result.Should().NotBeNull();
        }

        [Fact]
        public void Test_GetCustomerByAge_Should_Return_Empty_Result_When_Not_Matching()
        {
            //Arrange
            _customerRepositoryMock.Setup<Task<IEnumerable<Customer>>>(x => x.GetCustomers()).Returns(Task.FromResult<IEnumerable<Customer>>(customerData));
            //var customResponse = new { message = "Customers are not available." };

            //Act
            var objCustomer = _customerService.GetCustomersByAge(5);

            //Assert
            objCustomer.Result.Count().Should().Be(0);
        }
    }
}
