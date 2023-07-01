using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface ILogin
    {
        //Get new Login
        Users GetLogin(Login Login);      

        bool GetLogout();  
      
    }
}