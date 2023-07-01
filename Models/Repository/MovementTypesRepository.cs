using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class MovementTypesRepository : IMovementTypes
    {
         private readonly MarDomContext _context; 
       
        public MovementTypesRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateMovementTypes(MovementTypes MovementTypes)
        {  
            
        }

        public IEnumerable<MovementTypes> GetAllMovementTypes()
        {
            var MovementTypess = _context.MovementTypes.Where ( x => x.IsDeleted == false ).ToList();            
            return MovementTypess;
        }
       

        public void UpdateMovementTypes(MovementTypes MovementTypes)
        {
            _context.MovementTypes.Update(MovementTypes);
            _context.SaveChanges();
        }

        public void DeleteMovementTypes(MovementTypes MovementTypes)
        {
            MovementTypes.IsDeleted =true;
            _context.MovementTypes.Update(MovementTypes);
            _context.SaveChanges();
        }
    }
}