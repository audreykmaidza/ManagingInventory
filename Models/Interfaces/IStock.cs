using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IStock
    {
        //Create new Stock
        void CreateStock(GoodsMovements Stock);

        //Read all Stock
        IEnumerable<StockView> GetAllStock();   
        IEnumerable<StockView> GetStockByProductAndStorageLocation(int product, int storage); 
            

        //Update Stock
        void UpdateStock(Stock Stock);

        //Delete Stock
        void DeleteStock(Stock Stock);
    }
}