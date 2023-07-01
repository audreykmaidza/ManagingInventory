using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarDom.Models.Interfaces;
using MarDom.Models;

namespace MarDom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
       private readonly  IProducts _repository;
        
        public ProductsController(IProducts repository )
        {
            _repository = repository;
        }

        //Create Products
        [HttpPost("CreateProducts")] 
        public void  CreateProducts([FromBody]Products Products)
        {
             _repository.CreateProducts(Products);  
        }

        //Read Products
        [HttpGet("GetAllProducts")] 
        public IEnumerable<Products>  GetAllProducts()
        {
            return _repository.GetAllProducts();
        }              
       
        //Update Products
        [HttpPost("UpdateProducts")] 
        public void  UpdateProducts([FromBody]Products Products)
        {
            _repository.UpdateProducts(Products);
        }

        //Delete Products
        [HttpPost("DeleteProducts")] 
        public void  DeleteProducts([FromBody]Products Products)
        {
            _repository.DeleteProducts(Products);
        }
    }
}
