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
    public class MovementTypesController : ControllerBase
    {
       private readonly  IMovementTypes _repository;
        
        public MovementTypesController(IMovementTypes repository )
        {
            _repository = repository;
        }

        //Create MovementTypes
        [HttpPost("CreateMovementTypes")] 
        public void  CreateMovementTypes([FromBody]MovementTypes MovementTypes)
        {
             _repository.CreateMovementTypes(MovementTypes);  
        }

        //Read MovementTypes
        [HttpGet("GetAllMovementTypes")] 
        public IEnumerable<MovementTypes>  GetAllMovementTypes()
        {
            return _repository.GetAllMovementTypes();
        }              
       
        //Update MovementTypes
        [HttpPost("UpdateMovementTypes")] 
        public void  UpdateMovementTypes([FromBody]MovementTypes MovementTypes)
        {
            _repository.UpdateMovementTypes(MovementTypes);
        }

        //Delete MovementTypes
        [HttpPost("DeleteMovementTypes")] 
        public void  DeleteMovementTypes([FromBody]MovementTypes MovementTypes)
        {
            _repository.DeleteMovementTypes(MovementTypes);
        }
    }
}
