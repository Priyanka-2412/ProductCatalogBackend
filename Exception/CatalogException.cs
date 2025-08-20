using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogBackend.Exception
{
    public class CatalogException : System.Exception
    {
        public CatalogException(string message) : base(message) { }
    }
}
