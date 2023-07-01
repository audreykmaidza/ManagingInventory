using System.Collections.Generic;


namespace MarDom.Models.Interfaces
{
    public interface IMovementTypes
    {
        //Create new MovementTypes
        void CreateMovementTypes(MovementTypes MovementTypes);

        //Read all MovementTypes
        IEnumerable<MovementTypes> GetAllMovementTypes();        

        //Update MovementTypes
        void UpdateMovementTypes(MovementTypes MovementTypes);

        //Delete MovementTypes
        void DeleteMovementTypes(MovementTypes MovementTypes);
    }
}