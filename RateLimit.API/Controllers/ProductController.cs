﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new {Id=1,Name="Kalem",Price=20});
        }
        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new {Status= "Succes"});
        }
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
        //api/product/kalem/30
        [HttpGet("{Name}{{price}")]
        public IActionResult GetProduct(string name,int price)
        {
            return Ok(name);
        }
    }
}
