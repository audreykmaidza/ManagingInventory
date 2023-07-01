using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IGoodsMovements
    {
        //Create new GoodsMovements
        void CreateGoodsMovements(GoodsMovements GoodsMovements);

        //Read all GoodsMovements
        IEnumerable<GoodsMovements> GetAllGoodsMovements();    

        IEnumerable<GoodsMovementsView> GetAllGoodsMovementsView();      

        //Update GoodsMovements
        void UpdateGoodsMovements(GoodsMovements GoodsMovements);

        //Delete GoodsMovements
        void DeleteGoodsMovements(GoodsMovements GoodsMovements);
    }
}