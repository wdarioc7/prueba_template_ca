using MediatR;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdt_ms_template_netcore_ca.Application.Queries
{
    public record GetProductByIdQuery(uint ProductId) : IRequest<ProductEntity>;

    public class GetProductByIdQueryHandler(IProductRepository ProductRepository)
        : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await ProductRepository.GetProductByIdAsync(request.ProductId);
        }
    }
}
