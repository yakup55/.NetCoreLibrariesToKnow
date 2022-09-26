﻿using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using System;

namespace FluentValidationApp.Web.Mapping
{
    public class EventDateProfile:Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDto, EventDate>().ForMember(x=>x.Date,opt=>opt.MapFrom(x=>new DateTime(x.Year,x.Month,x.Day)));

            CreateMap<EventDate,EventDto>()
                .ForMember(x=>x.Year,opt=>opt.MapFrom(x=>x.Date.Year))
                .ForMember(x=>x.Month,opt=>opt.MapFrom(x=>x.Date.Month))
                .ForMember(x=>x.Day,opt=>opt.MapFrom(x=>x.Date.Day));
        }
    }
}
