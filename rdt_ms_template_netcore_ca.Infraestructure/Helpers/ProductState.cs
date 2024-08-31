using Microsoft.EntityFrameworkCore.Infrastructure;

namespace rdt_ms_template_netcore_ca.Infraestructure.Helpers
{
    public class ProductState
    {
        public uint Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Quantity { get; set; }

        public decimal? BuyPrice { get; set; }

        public decimal SalePrice { get; set; }

        public uint CategorieId { get; set; }

        public int? MediaId { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

        public int? Stock { get; set; }

        public string? Description { get; set; }

        public int? Discount { get; set; }

        public int? Total_price { get; set; }

     
    }
}