using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class GoodsMovementsRepository : IGoodsMovements
    {
         private readonly MarDomContext _context; 
       
        public GoodsMovementsRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateGoodsMovements(GoodsMovements GoodsMovements)
        {  
            _context.GoodsMovements.Add(GoodsMovements);
            _context.SaveChanges();
        }

        public IEnumerable<GoodsMovements> GetAllGoodsMovements()
        {
            var GoodsMovementss = _context.GoodsMovements.Where ( x => x.IsDeleted == false ).ToList();            
            return GoodsMovementss;
        }

        public IEnumerable<GoodsMovementsView> GetAllGoodsMovementsView()
        {
            var GoodsMovementsView =  (from gm in _context.GoodsMovements
                                        join pd in _context.Products on gm.Idproduct equals pd.Idproduct
                                        join u in _context.Users on gm.Iduser equals u.Iduser
                                        // join sl in _context.StorageLocations on gm.IdstorageLocationFrom equals sl.IdstorageLocation
                                        join mt in _context.MovementTypes on gm.IdmovementType equals mt.IdmovementType
                                        where gm.IsDeleted == false
                                        select new GoodsMovementsView{
                                            Date = gm.Date,
                                            MovementType = mt.Description,
                                            Product = pd.Description,
                                            Quantity = gm.Quantity,
                                            StorageLocationFrom = (from sl in _context.StorageLocations where sl.IdstorageLocation == gm.IdstorageLocationFrom 
                                                                    select  sl.Description).FirstOrDefault(),
                                            StorageLocationTo = (from sl in _context.StorageLocations where sl.IdstorageLocation == gm.IdstorageLocationTo 
                                                                    select  sl.Description).FirstOrDefault(),
                                            User = u.Name + " " + u.LastName


                                        }).ToList();

            
                    
             return GoodsMovementsView;
        }
       

        public void UpdateGoodsMovements(GoodsMovements GoodsMovements)
        {
            _context.GoodsMovements.Update(GoodsMovements);
            _context.SaveChanges();
        }

        public void DeleteGoodsMovements(GoodsMovements GoodsMovements)
        {
            GoodsMovements.IsDeleted =true;
            _context.GoodsMovements.Update(GoodsMovements);
            _context.SaveChanges();
        }
    }
}