using MediatR;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdt_ms_template_netcore_ca.Application.Commands
{
    public record DeleteProductCommand(uint ProductId) : IRequest<bool>;

    internal class DeleteProductCommandHandler(IProductRepository ProductRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await ProductRepository.DeleteProductAsync(request.ProductId);
        }
    }
}
