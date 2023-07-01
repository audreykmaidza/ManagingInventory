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
    public class StockController : ControllerBase
    {
       private readonly  IStock _repository;
        
        public StockController(IStock repository )
        {
            _repository = repository;
        }

        //Create Stock
        [HttpPost("CreateStock")] 
        public void  CreateStock([FromBody]GoodsMovements GoodsMovements)
        {
             _repository.CreateStock(GoodsMovements);  
        }

        //Read Stock
        [HttpGet("GetAllStock")] 
        public IEnumerable<StockView>  GetAllStock()
        {
            return _repository.GetAllStock();
        }    

        [HttpGet("GetStockByProductAndStorageLocation/{idProduct}/{idStorage}")] 
        public IEnumerable<StockView>  GetStockByProductAndStorageLocation(int idProduct, int idStorage )
        {
            return _repository.GetStockByProductAndStorageLocation(idProduct, idStorage);
        }           
       
        //Update Stock
        [HttpPost("UpdateStock")] 
        public void  UpdateStock([FromBody]Stock Stock)
        {
            _repository.UpdateStock(Stock);
        }

        //Delete Stock
        [HttpPost("DeleteStock")] 
        public void  DeleteStock([FromBody]Stock Stock)
        {
            _repository.DeleteStock(Stock);
        }
    }
}
