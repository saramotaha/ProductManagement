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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediator mediator;

        public CreateProductHandler(IProductRepository productRepository , ICategoryRepository categoryRepository , IMediator mediator)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mediator = mediator;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
                var categoryExists = await categoryRepository.CategoryExists(request.CategoryRef);
                if (!categoryExists)
                    throw new Exception("Category not found");
            
            Product product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryRef = request.CategoryRef


            };
            await productRepository.AddAsync(product);
            await productRepository.SaveAsync();

           

            return product;

        }
    }
}
