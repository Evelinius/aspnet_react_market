using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conduit.Domain;
using Conduit.Infrastructure;
using FluentValidation;
using MediatR;

namespace Conduit.Features.Products
{
    public class Create
    {
        public class ProductData
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
        }

        public class ProductValidator : AbstractValidator<ProductData>
        {
            public ProductValidator()
            {
                RuleFor(x => x.Name).NotEmpty().NotNull();
            }
        }

        public class Command:IRequest<ProductEnvelope>
        {
            public ProductData Product { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Product).NotNull().SetValidator(new ProductValidator());
            }
        }

        public class Handler : IRequestHandler<Command, ProductEnvelope>
        {
            private readonly ConduitContext _context;

            public Handler(ConduitContext context)
            {
                _context = context;
            }

            public async Task<ProductEnvelope> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Name = request.Product.Name,
                    Description = request.Product.Description,
                    Image = request.Product.Image
                };

                await _context.Products.AddAsync(product, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ProductEnvelope(product);
            }
        }
    }
}
