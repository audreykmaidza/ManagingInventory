using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class StorageLocations
    {
        public StorageLocations()
        {
            GoodsMovementsIdstorageLocationFromNavigation = new HashSet<GoodsMovements>();
            GoodsMovementsIdstorageLocationToNavigation = new HashSet<GoodsMovements>();
            Stock = new HashSet<Stock>();
        }

        public int IdstorageLocation { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double? MaxQtty { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<GoodsMovements> GoodsMovementsIdstorageLocationFromNavigation { get; set; }
        public virtual ICollection<GoodsMovements> GoodsMovementsIdstorageLocationToNavigation { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
