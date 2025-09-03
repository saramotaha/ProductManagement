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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public UpdateProductHandler(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var categoryExists = await categoryRepository.CategoryExists(request.CategoryRef);
            if (!categoryExists)
                throw new Exception("Category not found");

            var existingProduct = await productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                throw new Exception("Product not found");

           await productRepository.UpdateAsync(new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryRef = request.CategoryRef,
                UpdatedAt = request.UpdatedAt ?? DateTime.UtcNow
            });

            await productRepository.SaveAsync();

            return existingProduct;
        }

    }
}
