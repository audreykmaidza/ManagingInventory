using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IProducts
    {
        //Create new Products
        void CreateProducts(Products Products);

        //Read all Products
        IEnumerable<Products> GetAllProducts();        

        //Update Products
        void UpdateProducts(Products Products);

        //Delete Products
        void DeleteProducts(Products Products);
    }
}