using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class LoginRepository : ILogin
    {
         private readonly MarDomContext _context; 
       
        public LoginRepository(MarDomContext context)
        {
            _context = context;
        }

        public Users GetLogin(Login Login)
        {  
            var validate = _context.Users.Where(x=>x.Email == Login.Email && x.Password == Login.Password && x.IsDeleted == false).FirstOrDefault();
            if (validate != null)
            {
                validate.Password = "";
            }

            return validate;
            
        }

        public bool GetLogout()
        {
           return true; 
        }
    }
}