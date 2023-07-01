using System;


namespace MarDom.Models
{
    public partial class StockView
    {        
        public string Product { get; set; }
        public string StorageLocation { get; set; }
        public double Quantity { get; set; }   
        public string UnitOfMeasurement {get; set;}    

    }
}
