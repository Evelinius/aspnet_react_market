using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Conduit.Features.Products
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ProductsEnvelope> Get()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ProductEnvelope> Create([FromBody] Create.Command command)
        {
            return await _mediator.Send(command);
        }

    }
}
