using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile:Profile
    {
        //ReverseMap metodu tam tersinide yapıyor
        //ForMember metodu Customer daki isimlerle CustomerDto daki isimler farklıysa cevirme yapar
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            
          //  CreateMap<Customer, CustomerDto>()
          //  .ForMember(dest=>.Isım,opt=>opt.MapForm(x=>x.Name));
          //  .ForMember(dest=>.Eposta,opt=>opt.MapForm(x=>x.Mail));
          //  .ForMember(dest=>.Yas,opt=>opt.MapForm(x=>x.Age));
        }
    }
}
