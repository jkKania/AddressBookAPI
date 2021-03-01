using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookAPI.Application.Interfaces;
using AddressBookAPI.Domain.Model;
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

        public AddressBookController(ILogger<AddressBookController> logger, IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAddress()
        {
            _logger.LogInformation("Log GetAddress request");

            var address = _addressBookService.GetLastAddedAddress();
            if (address == null)
            {
                return NotFound("gowno");
            }
            return Ok(address);
        }
        [HttpGet]
        public IActionResult GetAddressByCity(string cityName)
        {
            _logger.LogInformation("Log GetAddressByCity request");

            var address = _addressBookService.GetAddressByCity(cityName);
            if (address == null || !address.Any())
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] Address address)
        {
            _logger.LogInformation("Log PostCity request");

            if (address == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            _addressBookService.AddAddress(address);
            return Ok();
        }
    }
}