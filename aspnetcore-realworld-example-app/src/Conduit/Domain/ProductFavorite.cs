using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conduit.Domain
{
    public class ProductFavorite
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
