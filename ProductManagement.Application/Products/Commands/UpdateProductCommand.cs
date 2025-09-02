using MediatR;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands
{
    public class UpdateProductCommand:IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

        public int StockQuantity { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
