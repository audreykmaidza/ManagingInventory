using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IUsers
    {
        //Create new Users
        void CreateUsers(Users Users);

        //Read all Users
        IEnumerable<Users> GetAllUsers();        

        //Update Users
        void UpdateUsers(Users Users);

        //Delete Users
        void DeleteUsers(Users Users);
    }
}