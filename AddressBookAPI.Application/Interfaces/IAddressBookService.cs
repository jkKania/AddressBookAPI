using AddressBookAPI.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Application.Interfaces
{
    public interface IAddressBookService
    {
        void AddAddress(Address address);
        Address GetLastAddedAddress();
        IEnumerable<Address> GetAddressByCity(string cityName);
    }
}
