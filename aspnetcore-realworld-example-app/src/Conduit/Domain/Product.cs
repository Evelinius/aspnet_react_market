using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Conduit.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }

        [JsonIgnore]
        public List<ProductFavorite> ProductFavorites { get; set; }
    }
}
