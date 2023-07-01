using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class UsersRepository : IUsers
    {
         private readonly MarDomContext _context; 
       
        public UsersRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateUsers(Users Users)
        {  
            
        }

        public IEnumerable<Users> GetAllUsers()
        {
            var Userss = _context.Users.Where ( x => x.IsDeleted == false ).ToList();            
            return Userss;
        }
       

        public void UpdateUsers(Users Users)
        {
            _context.Users.Update(Users);
            _context.SaveChanges();
        }

        public void DeleteUsers(Users Users)
        {
            Users.IsDeleted =true;
            _context.Users.Update(Users);
            _context.SaveChanges();
        }
    }
}