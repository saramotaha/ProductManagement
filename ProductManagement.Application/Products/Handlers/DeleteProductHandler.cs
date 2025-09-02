using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Handlers
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
          var product=  await productRepository.DeleteAsync(request.Id);

            await productRepository.SaveAsync();

            return product;
            

        }
    }
}
