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
    public class StorageLocationsController : ControllerBase
    {
       private readonly  IStorageLocations _repository;
        
        public StorageLocationsController(IStorageLocations repository )
        {
            _repository = repository;
        }

        //Create StorageLocations
        [HttpPost("CreateStorageLocations")] 
        public void  CreateStorageLocations([FromBody]StorageLocations StorageLocations)
        {
             _repository.CreateStorageLocations(StorageLocations);  
        }

        //Read StorageLocations
        [HttpGet("GetAllStorageLocations")] 
        public IEnumerable<StorageLocations>  GetAllStorageLocations()
        {
            return _repository.GetAllStorageLocations();
        }              
       
        //Update StorageLocations
        [HttpPost("UpdateStorageLocations")] 
        public void  UpdateStorageLocations([FromBody]StorageLocations StorageLocations)
        {
            _repository.UpdateStorageLocations(StorageLocations);
        }

        //Delete StorageLocations
        [HttpPost("DeleteStorageLocations")] 
        public void  DeleteStorageLocations([FromBody]StorageLocations StorageLocations)
        {
            _repository.DeleteStorageLocations(StorageLocations);
        }
    }
}
