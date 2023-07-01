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
    public class GoodsMovementsController : ControllerBase
    {
       private readonly  IGoodsMovements _repository;
        
        public GoodsMovementsController(IGoodsMovements repository )
        {
            _repository = repository;
        }

        //Create GoodsMovements
        [HttpPost("CreateGoodsMovements")] 
        public void  CreateGoodsMovements([FromBody]GoodsMovements GoodsMovements)
        {
             _repository.CreateGoodsMovements(GoodsMovements);  
        }

        //Read GoodsMovements
        [HttpGet("GetAllGoodsMovements")] 
        public IEnumerable<GoodsMovements>  GetAllGoodsMovements()
        {
            return _repository.GetAllGoodsMovements();
        }   

        [HttpGet("GetAllGoodsMovementsView")] 
        public IEnumerable<GoodsMovementsView>  GetAllGoodsMovementsView()
        {
            return _repository.GetAllGoodsMovementsView();
        }            
       
        //Update GoodsMovements
        [HttpPost("UpdateGoodsMovements")] 
        public void  UpdateGoodsMovements([FromBody]GoodsMovements GoodsMovements)
        {
            _repository.UpdateGoodsMovements(GoodsMovements);
        }

        //Delete GoodsMovements
        [HttpPost("DeleteGoodsMovements")] 
        public void  DeleteGoodsMovements([FromBody]GoodsMovements GoodsMovements)
        {
            _repository.DeleteGoodsMovements(GoodsMovements);
        }
    }
}
