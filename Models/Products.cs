using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class Products
    {
        public Products()
        {
            GoodsMovements = new HashSet<GoodsMovements>();
            Stock = new HashSet<Stock>();
        }

        public int Idproduct { get; set; }
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public string Category { get; set; }
        public string UnitOfMeasurement { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<GoodsMovements> GoodsMovements { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
