using Microsoft.EntityFrameworkCore;
using System;

namespace FluentValidationApp.Web.Models
{
    public class AppDbContex:DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex>options):base(options)
        {

        }
        public DbSet<Customer>Customers  { get; set; }
        public DbSet <Address>Addresses { get; set; }

    }
}
