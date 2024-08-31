using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using rdt_ms_template_netcore_ca.Application.Commands;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Application.Queries;
using System.Threading.Tasks;
using rdt_ms_template_netcore_ca.Helpers;
using LazyCache;

namespace rdt_ms_template_netcore_ca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {
      
        [HttpPost("")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductEntity Product)
        {
            var result = await sender.Send(new AddProductCommand(Product));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var result = await sender.Send(new GetAllProductQuery()); 
            return Ok(result);
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] uint ProductId)
        {
            var result = await sender.Send(new GetProductByIdQuery(ProductId));
            return Ok(result);
        }

        [HttpPut("{ProductId}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] uint ProductId, [FromBody] ProductEntity Product)
        {
            var result = await sender.Send(new UpdateProductCommand(ProductId, Product));
            return Ok(result);
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] uint productId)
        {
            var result = await sender.Send(new DeleteProductCommand(productId));
            return Ok(result);
        }
    }
}
