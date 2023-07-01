using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class MovementTypes
    {
        public MovementTypes()
        {
            GoodsMovements = new HashSet<GoodsMovements>();
        }

        public int IdmovementType { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<GoodsMovements> GoodsMovements { get; set; }
    }
}
