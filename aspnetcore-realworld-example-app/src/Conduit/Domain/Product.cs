using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Conduit.Domain
{
    public class Product
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
