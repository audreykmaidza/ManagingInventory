using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class StockRepository : IStock
    {
         private readonly MarDomContext _context; 
       
        public StockRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateStock(GoodsMovements GoodsMovements)
        {  
            //add to producto to storage location
            // see if product exist in stock
            var checkProductAdd =  _context.Stock.FirstOrDefault(x=>x.Idproduct == GoodsMovements.Idproduct && x.IdstorageLocation == GoodsMovements.IdstorageLocationTo  && x.IsDeleted == false);
            Stock stockAdd = new Stock();
            if (checkProductAdd is null) // no exist this product
            {
                stockAdd.Idproduct = GoodsMovements.Idproduct;
                stockAdd.IdstorageLocation = GoodsMovements.IdstorageLocationTo;
                stockAdd.Quantity = GoodsMovements.Quantity;
                stockAdd.IsDeleted = false;
                _context.Stock.Add(stockAdd);
               
            }
            else{ // existe the product
                stockAdd = checkProductAdd;
                stockAdd.Quantity += GoodsMovements.Quantity;
                _context.Stock.Update(stockAdd);
            }
            
            _context.SaveChanges();

            // dismiss producto from storage location
            // see if product exist in stock
            var checkProduct =  _context.Stock.FirstOrDefault(x=>x.Idproduct == GoodsMovements.Idproduct && x.IdstorageLocation == GoodsMovements.IdstorageLocationFrom && x.IsDeleted == false);
            Stock stockDM = new Stock();
            if (checkProduct is null) // no exist this product
            {
                stockDM.Idproduct = GoodsMovements.Idproduct;
                stockDM.IdstorageLocation = GoodsMovements.IdstorageLocationFrom;
                stockDM.Quantity -= GoodsMovements.Quantity;
                stockDM.IsDeleted = false;
                _context.Stock.Add(stockDM);
               
            }
            else{ // existe the product
                stockDM = checkProduct;
                stockDM.Quantity -= GoodsMovements.Quantity;
                _context.Stock.Update(stockDM);
            }
            
            _context.SaveChanges();
        }

        public IEnumerable<StockView> GetAllStock()
        {

            var Stocks = (from st in _context.Stock 
                            join pd in _context.Products on st.Idproduct equals pd.Idproduct
                            join sl in _context.StorageLocations on st.IdstorageLocation equals sl.IdstorageLocation
                            orderby sl.Description ascending
                            select new   StockView{
                                Product = pd.Description,
                                StorageLocation = sl.Description,
                                Quantity = st.Quantity,
                                UnitOfMeasurement = pd.UnitOfMeasurement

                            } ).ToList();         
            return Stocks;
        }

        public IEnumerable<StockView> GetStockByProductAndStorageLocation(int product, int storage)
        {
            IEnumerable<StockView> Stocks ;
            if (product == storage && product == 0)
            {
                 Stocks = GetAllStock();       
                
            }
            else if (product == 0 && storage > 0 )
            {
                Stocks = (from st in _context.Stock 
                                join pd in _context.Products on st.Idproduct equals pd.Idproduct
                                join sl in _context.StorageLocations on st.IdstorageLocation equals sl.IdstorageLocation
                                where sl.IdstorageLocation == storage
                                orderby sl.Description ascending
                                select new   StockView{
                                    Product = pd.Description,
                                    StorageLocation = sl.Description,
                                    Quantity = st.Quantity,
                                    UnitOfMeasurement = pd.UnitOfMeasurement
                                } ).ToList(); 
                
            }
            else if (product > 0 && storage == 0 )
            {
                Stocks = (from st in _context.Stock 
                                join pd in _context.Products on st.Idproduct equals pd.Idproduct
                                join sl in _context.StorageLocations on st.IdstorageLocation equals sl.IdstorageLocation
                                where pd.Idproduct == product
                                orderby sl.Description ascending
                                select new   StockView{
                                    Product = pd.Description,
                                    StorageLocation = sl.Description,
                                    Quantity = st.Quantity,
                                    UnitOfMeasurement = pd.UnitOfMeasurement
                                } ).ToList(); 
                
            }
            else  
            {
                Stocks = (from st in _context.Stock 
                                join pd in _context.Products on st.Idproduct equals pd.Idproduct
                                join sl in _context.StorageLocations on st.IdstorageLocation equals sl.IdstorageLocation
                                where pd.Idproduct == product 
                                where sl.IdstorageLocation == storage
                                orderby sl.Description ascending
                                select new   StockView{
                                    Product = pd.Description,
                                    StorageLocation = sl.Description,
                                    Quantity = st.Quantity,
                                    UnitOfMeasurement = pd.UnitOfMeasurement
                                } ).ToList(); 
                
            }
            return Stocks;
        }
       

        public void UpdateStock(Stock Stock)
        {
            _context.Stock.Update(Stock);
            _context.SaveChanges();
        }

        public void DeleteStock(Stock Stock)
        {
            Stock.IsDeleted =true;
            _context.Stock.Update(Stock);
            _context.SaveChanges();
        }
    }
}