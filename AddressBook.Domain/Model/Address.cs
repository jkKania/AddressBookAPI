using AddressBookAPI.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Domain.Model
{
    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Address()
        {
            Id = Guid.NewGuid();
        }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;
    }
}
