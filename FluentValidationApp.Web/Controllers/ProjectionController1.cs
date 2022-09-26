using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationApp.Web.Controllers
{
    public class ProjectionController1 : Controller
    {
        private readonly IMapper mapper;

        public ProjectionController1(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EventDto eventDto)
        {
          EventDate eventDate=mapper.Map<EventDate>(eventDto);
            ViewBag.date = eventDate.Date.ToShortDateString();
            return View();
        }
    }
}
