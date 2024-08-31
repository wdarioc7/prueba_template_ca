using rdt_ms_template_netcore_ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace rdt_ms_template_netcore_ca.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductAsync();
        Task<ProductEntity> GetProductByIdAsync(uint id);
        Task<ProductEntity> AddProductAsync(ProductEntity entity);
        Task<ProductEntity> UpdateProductAsync(uint ProductId, ProductEntity entity);
        Task<bool> DeleteProductAsync(uint ProductId);
    }

}
