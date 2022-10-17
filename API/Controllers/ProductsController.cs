using System;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
       
        [HttpGet]
        public string GetProducts()
        {
            return "This is going to be a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Single Product " + id;
        }


    }
}

