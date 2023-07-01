using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IStorageLocations
    {
        //Create new StorageLocations
        void CreateStorageLocations(StorageLocations StorageLocations);

        //Read all StorageLocations
        IEnumerable<StorageLocations> GetAllStorageLocations();        

        //Update StorageLocations
        void UpdateStorageLocations(StorageLocations StorageLocations);

        //Delete StorageLocations
        void DeleteStorageLocations(StorageLocations StorageLocations);
    }
}