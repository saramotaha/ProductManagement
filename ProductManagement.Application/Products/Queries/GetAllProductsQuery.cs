using MediatR;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}
