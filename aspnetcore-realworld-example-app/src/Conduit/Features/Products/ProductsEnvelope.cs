using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conduit.Domain;

namespace Conduit.Features.Products
{
    public class ProductsEnvelope
    {
        public List<Product> Products { get; set; }
        public int ProductsCount { get; set; }
    }
}
