using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Conduit.Domain;
using Conduit.Infrastructure;
using Conduit.Infrastructure.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Features.Products
{
    public class Like
    {
        public class Command : IRequest<ProductEnvelope>
        {
            public Command(int productId)
            {
                ProductId = productId;
            }

            public int ProductId { get; }
        }

        public class QueryHandler : IRequestHandler<Command, ProductEnvelope>
        {
            private readonly ConduitContext _context;
            private readonly ICurrentUserAccessor _currentUserAccessor;

            public QueryHandler(ConduitContext context, ICurrentUserAccessor currentUserAccessor)
            {
                _context = context;
                _currentUserAccessor = currentUserAccessor;
            }

            public async Task<ProductEnvelope> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);

                if (product == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Article = Constants.NOT_FOUND });
                }

                var person = await _context.Persons.FirstOrDefaultAsync(x => x.Username == _currentUserAccessor.GetCurrentUsername(), cancellationToken);

                var favorite = await _context.ProductFavorite
                    .FirstOrDefaultAsync(x => x.ProductId == product.ProductId && x.PersonId == person.PersonId, cancellationToken);

                if (favorite == null)
                {
                    favorite = new ProductFavorite()
                    {
                        Product = product,
                        ProductId = product.ProductId,
                        Person = person,
                        PersonId = person.PersonId
                    };
                    await _context.ProductFavorite.AddAsync(favorite, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return new ProductEnvelope(await _context.Products.GetAllData()
                    .FirstOrDefaultAsync(x => x.ProductId == product.ProductId, cancellationToken));
            }
        }
    }
}
