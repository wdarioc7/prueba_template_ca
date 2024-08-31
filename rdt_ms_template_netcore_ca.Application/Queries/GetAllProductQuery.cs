using MediatR;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;

namespace rdt_ms_template_netcore_ca.Application.Queries
{
    public record GetAllProductQuery() : IRequest<IEnumerable<ProductEntity>>;
    public class GetAllProductQueryHandler(IProductRepository ProductRepository)
        : IRequestHandler<GetAllProductQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await ProductRepository.GetAllProductAsync();
        }
    }
}
