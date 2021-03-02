using AddressBookAPI.Application.Interfaces;
using AddressBookAPI.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBookAPI.Tests
{
    public class AddressBookServiceFake : IAddressBookService
    {
        private readonly List<Address> _addressBook;
        public AddressBookServiceFake()
        {
            _addressBook = new List<Address>() {
                new Address() { Street = "Jana Pawła", BuildingNumber = "3", City = "Kraków", Country = "Polska", FlatNumber = 11, ZipCode = "30-063" },
                new Address() { Street = "Bohaterów Warszawy", BuildingNumber = "21", City = "Warszawa", Country = "Polska", FlatNumber = 5, ZipCode = "01-934" },
                new Address() { Street = "Willowa", BuildingNumber = "34a", City = "Bielsko - Biała", Country = "Polska", FlatNumber = 2, ZipCode = "43-300" }
             };
        }

        public void AddAddress(Address address)
        {
            _addressBook.Add(address);
        }

        public Address GetLastAddedAddress()
        {
            return _addressBook.OrderByDescending(x => x.RecordCreateTime).First();
        }

        public IEnumerable<Address> GetAddressesByCity(string cityName)
        {
            return _addressBook.Where(name => name.City.Equals(cityName));
        }

        public IEnumerable<Address> GetAll()
        {
            return _addressBook;
        }
    }
}
