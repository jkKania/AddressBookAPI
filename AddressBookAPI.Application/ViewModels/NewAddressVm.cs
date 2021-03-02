using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Application.ViewModels
{
    public class NewAddressVm
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
