using AddressBookAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Infrastructure
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
    }
}
