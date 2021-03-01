using AddressBookAPI.Application.Interfaces;
using AddressBookAPI.Domain.Model;
using AddressBookAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Application.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IRepository<Address> _repository;

        public AddressBookService(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public void AddAddress(Address address)
        {
            _repository.Create(address);
        }

        public IEnumerable<Address> GetAddressByCity(string cityName)
        {
            return _repository.SearchBy(x => x.City.Equals(cityName));
        }

        public Address GetLastAddedAddress()
        {
            return _repository.GetLastAdded();
        }
    }
}
