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
    public class UsersController : ControllerBase
    {
       private readonly  IUsers _repository;
        
        public UsersController(IUsers repository )
        {
            _repository = repository;
        }

        //Create Users
        [HttpPost("CreateUsers")] 
        public void  CreateUsers([FromBody]Users Users)
        {
             _repository.CreateUsers(Users);  
        }

        //Read Users
        [HttpGet("GetAllUsers")] 
        public IEnumerable<Users>  GetAllUsers()
        {
            return _repository.GetAllUsers();
        }              
       
        //Update Users
        [HttpPost("UpdateUsers")] 
        public void  UpdateUsers([FromBody]Users Users)
        {
            _repository.UpdateUsers(Users);
        }

        //Delete Users
        [HttpPost("DeleteUsers")] 
        public void  DeleteUsers([FromBody]Users Users)
        {
            _repository.DeleteUsers(Users);
        }
    }
}
