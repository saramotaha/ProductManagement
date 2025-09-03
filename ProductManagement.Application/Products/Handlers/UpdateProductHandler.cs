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
            if (request.CategoryId.HasValue)
            {
                var categoryExists = await categoryRepository.CategoryExists(request.CategoryId.Value);
                if (!categoryExists)
                    throw new Exception("Category not found");
            }


            Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId,
                UpdatedAt = request.UpdatedAt
            };


            await  productRepository.UpdateAsync(product);

            await productRepository.SaveAsync();
            return product;




        }
    }
}
