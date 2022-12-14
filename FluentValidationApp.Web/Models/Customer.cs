using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public DateTime?  BirthDay { get; set; }

        //Customer.Address[1].Id
        public IList<Address> Adresses { get; set; }

        public Gender Gender { get; set; }
    }
}
