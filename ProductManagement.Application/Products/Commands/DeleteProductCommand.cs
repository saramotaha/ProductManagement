using MediatR;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands
{
    public class DeleteProductCommand:IRequest<Product>
    {
        public int Id { get; set; }
        
    }
}
