using System;
using System.Collections.Generic;

namespace MarDom.Models
{
    public partial class Users
    {
        public Users()
        {
            GoodsMovements = new HashSet<GoodsMovements>();
        }

        public int Iduser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<GoodsMovements> GoodsMovements { get; set; }
    }
}
