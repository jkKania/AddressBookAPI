using AddressBookAPI.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Infrastructure
{
    public class DbInitializer
    {
        public static void SeedAddresses(ApiContext context)
        {
            context.Addresses.Add(new Address() { Street = "Grunwaldzka", BuildingNumber = "11", City = "Katowice", Country = "Polska", FlatNumber = 33, ZipCode = "40-611" });
            context.Addresses.Add(new Address() { Street = "Jana Pawła", BuildingNumber = "3", City = "Kraków", Country = "Polska", FlatNumber = 11, ZipCode = "30-063" });
            context.Addresses.Add(new Address() { Street = "Bohaterów Warszawy", BuildingNumber = "21", City = "Warszawa", Country = "Polska", FlatNumber = 5, ZipCode = "01-934" });
            context.Addresses.Add(new Address() { Street = "Willowa", BuildingNumber = "34a", City = "Bielsko - Biała", Country = "Polska", FlatNumber = 2, ZipCode = "43-300" });
            context.SaveChanges();
        }
    }
}
