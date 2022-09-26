using System;

namespace FluentValidationApp.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }

        public string FullName { get; set; }

        //dönüs tipleri aynı olmalı
        //CreditCard class ismi Number da property
        public string CreditCardNumber { get; set; }

        //CreditCard class ismi ValidDate da property
        public DateTime CreditCardValidDate { get; set; }
    }
}
