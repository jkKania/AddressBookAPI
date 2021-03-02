using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookAPI.Application.Interfaces;
using AddressBookAPI.Application.ViewModels;
using AddressBookAPI.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBookAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _addressBookService;
        private readonly ILogger<AddressBookController> _logger;
        private readonly IMapper _mapper;

        public AddressBookController(ILogger<AddressBookController> logger, IMapper mapper, IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAddress()
        {
            _logger.LogInformation("AddressBookController: GetAddress request");

            var address = _addressBookService.GetLastAddedAddress();
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }
        [HttpGet]
        public IActionResult GetAddressByCity(string cityName)
        {
            _logger.LogInformation("AddressBookController: GetAddressByCity request");

            var address = _addressBookService.GetAddressByCity(cityName);
            if (address == null || !address.Any())
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] NewAddressVm addressVm)
        {
            _logger.LogInformation("AddressBookController: PostCity request");

            if (addressVm == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            Address address = _mapper.Map<Address>(addressVm);

            _addressBookService.AddAddress(address);
            return Ok();
        }
    }
}