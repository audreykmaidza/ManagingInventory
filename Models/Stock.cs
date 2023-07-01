using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class Stock
    {
        public int Idstock { get; set; }
        public int Idproduct { get; set; }
        public int IdstorageLocation { get; set; }
        public double Quantity { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Products IdproductNavigation { get; set; }
        public virtual StorageLocations IdstorageLocationNavigation { get; set; }
    }
}
