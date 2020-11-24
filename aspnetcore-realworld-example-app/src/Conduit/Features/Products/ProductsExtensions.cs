using System;
using System.Linq;
using Conduit.Domain;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Features.Products
{
    public static class ProductsExtensions
    {
        public static IQueryable<Product> GetAllData(this DbSet<Product> products)
        {
            return products
                .Include(x => x.Name)
                .Include(x => x.ProductFavorites)
                .AsNoTracking();
        }
    }
}
