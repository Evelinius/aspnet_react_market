using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conduit.Domain;

namespace Conduit.Features.Products
{
    public class ProductEnvelope
    {
        public ProductEnvelope(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
    }
}
