using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Services.Dtos.Products
{
    public class ProductUpdateDto
    {
        public long UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string MetaTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public int Quantity { get; set; }

        public bool IsShop { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public string? ProductImage { get; set; }
    }
}
