using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogBackend.Entities
{
    public class ProductAttribute
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
    }
}
