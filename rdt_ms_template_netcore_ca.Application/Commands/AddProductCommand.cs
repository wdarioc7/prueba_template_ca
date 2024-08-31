using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;

namespace rdt_ms_template_netcore_ca.Application.Commands
{
 
    public record AddProductCommand(ProductEntity Product) : IRequest<ProductEntity>;


    public class AddProductCommandHandler(IProductRepository ProductRepository)
        : IRequestHandler<AddProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await ProductRepository.AddProductAsync(request.Product);
        }
    }
}
