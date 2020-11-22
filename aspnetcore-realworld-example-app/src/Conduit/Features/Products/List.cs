using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conduit.Domain;
using Conduit.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Features.Products
{
    public class List
    {
        public class Query : IRequest<ProductsEnvelope> { }
        public class QueryHandler : IRequestHandler<Query, ProductsEnvelope>
        {
            private readonly ConduitContext _context;

            public QueryHandler(ConduitContext context)
            {
                _context = context;
            }

            public async Task<ProductsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var productsList = await _context.Products.ToListAsync();
                ProductsEnvelope productsEnvelope = new ProductsEnvelope
                {
                    Products = productsList,
                    ProductsCount = productsList.Count
                };
                
                return productsEnvelope;
            }
        }
    }
}
