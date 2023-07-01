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
    public class LoginController : ControllerBase
    {
       private readonly  ILogin _repository;
        
        public LoginController(ILogin repository )
        {
            _repository = repository;
        }

        //Get Login
        [HttpPost("GetLogin")] 
        public Users  GetLogin([FromBody]Login Login)
        {
            return _repository.GetLogin(Login);  
        }

        //Get Logout
        [HttpPost("GetLogout")] 
        public bool  GetLogout()
        {
             return _repository.GetLogout();  
        }

        
    }
}
