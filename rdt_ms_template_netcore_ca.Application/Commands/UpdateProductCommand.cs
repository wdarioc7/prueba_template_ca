using MediatR;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdt_ms_template_netcore_ca.Application.Commands
{
    public record UpdateProductCommand(uint ProductId, ProductEntity Product)
        : IRequest<ProductEntity>;
    public class UpdateProductCommandHandler(IProductRepository ProductRepository)
        : IRequestHandler<UpdateProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await ProductRepository.UpdateProductAsync(request.ProductId, request.Product);
        }
    }
}
