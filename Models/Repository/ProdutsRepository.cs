using System.Collections.Generic;
using System.Linq;
using MarDom.Models.Interfaces;


namespace MarDom.Models.Repository
{
    public class ProductsRepository : IProducts
    {
         private readonly MarDomContext _context; 
       
        public ProductsRepository(MarDomContext context)
        {
            _context = context;
        }

        public void CreateProducts(Products Products)
        {  
            _context.Products.Add(Products);
            _context.SaveChanges();
        }

        public IEnumerable<Products> GetAllProducts()
        {
            var Productss = _context.Products.Where ( x => x.IsDeleted == false ).ToList();            
            return Productss;
        }
       

        public void UpdateProducts(Products Products)
        {
            _context.Products.Update(Products);
            _context.SaveChanges();
        }

        public void DeleteProducts(Products Products)
        {
            Products.IsDeleted =true;
            _context.Products.Update(Products);
            _context.SaveChanges();
        }
    }
}