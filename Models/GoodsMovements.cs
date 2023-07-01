using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class GoodsMovements
    {
        public int IdgoodsMovements { get; set; }
        public int IdmovementType { get; set; }
        public int Idproduct { get; set; }
        public DateTime Date { get; set; }
        public double Quantity { get; set; }
        public int IdstorageLocationFrom { get; set; }
        public int IdstorageLocationTo { get; set; }
        public int Iduser { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual MovementTypes IdmovementTypeNavigation { get; set; }
        public virtual Products IdproductNavigation { get; set; }
        public virtual StorageLocations IdstorageLocationFromNavigation { get; set; }
        public virtual StorageLocations IdstorageLocationToNavigation { get; set; }
        public virtual Users IduserNavigation { get; set; }
    }
}
