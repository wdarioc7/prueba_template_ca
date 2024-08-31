using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rdt_ms_template_netcore_ca.Core.Entities;

public class ProductEntity
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

    [NotMapped]
    public int? Discount { get; set; } = null;
    [NotMapped]
    public int? Total_price { get; set; } = null;
}
