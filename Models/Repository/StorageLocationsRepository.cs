using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class StorageLocationsRepository : IStorageLocations
    {
         private readonly MarDomContext _context; 
       
        public StorageLocationsRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateStorageLocations(StorageLocations StorageLocations)
        {  
            _context.Add(StorageLocations);
            _context.SaveChanges();

        }

        public IEnumerable<StorageLocations> GetAllStorageLocations()
        {
            var StorageLocationss = _context.StorageLocations.Where ( x => x.IsDeleted == false ).ToList();            
            return StorageLocationss;
        }
       

        public void UpdateStorageLocations(StorageLocations StorageLocations)
        {
            _context.StorageLocations.Update(StorageLocations);
            _context.SaveChanges();
        }

        public void DeleteStorageLocations(StorageLocations StorageLocations)
        {
            StorageLocations.IsDeleted =true;
            _context.StorageLocations.Update(StorageLocations);
            _context.SaveChanges();
        }
    }
}