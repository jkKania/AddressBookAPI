using AddressBookAPI.Application.Interfaces;
using AddressBookAPI.Controllers;
using AddressBookAPI.Tests;
using AutoMapper;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using AddressBookAPI.Domain.Model;
using AddressBookAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AddressBook.Tests
{
    public class AddressBookControllerTest
    {
        AddressBookController _controller;
        IAddressBookService _service;

        public AddressBookControllerTest()
        {
            ///Arrange
            
            var _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<NewAddressVm, Address>(It.IsAny<NewAddressVm>())).Returns(new Address());

            var _logger = new Mock<ILogger<AddressBookController>>();

            _service = new AddressBookServiceFake();

            _controller = new AddressBookController(_logger.Object, _mapper.Object, _service);
        }

        [Fact]
        public void GetAddressTest()
        {
            ///Act
            var okResult = (OkObjectResult)_controller.GetAddress();
            var lastAdded = _service.GetAll().OrderByDescending(x => x.RecordCreateTime).First();

            ///Assert
            Assert.Equal(okResult.Value, lastAdded);
        }

        [Fact]
        public void GetAddressByCityTest()
        {
            ///Act
            var okResult = _controller.GetAddressByCity("Kraków");
            ///Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void PostCityResultTest()
        {
            ///Arrange
            NewAddressVm newAddress = new NewAddressVm()
            {
                Street = "Aleje Jerozolimskie",
                BuildingNumber = "31",
                FlatNumber = 21,
                City = "Warszawa",
                ZipCode = "01-032",
                Country = "Polska"
                
            };

            ///Act
            var okResult = _controller.PostCity(newAddress);
            ///Assert
            Assert.IsType<OkResult>(okResult);
        }
    }
}
