using System;

namespace MarDom.Models
{
    public partial class GoodsMovementsView
    {        
        public string MovementType { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public double Quantity { get; set; }
        public string StorageLocationFrom { get; set; }
        public string StorageLocationTo { get; set; }
        public string User { get; set; }        
  
    }
}
