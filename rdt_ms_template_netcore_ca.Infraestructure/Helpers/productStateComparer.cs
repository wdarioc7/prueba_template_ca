using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdt_ms_template_netcore_ca.Infraestructure.Helpers
{
    public class ProductStateComparer : IEqualityComparer<ProductState>
    {
        public bool Equals(ProductState x, ProductState y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(ProductState obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
