using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Categories.EventHandlers
{
    public class CategoryDeletedEventHandler : INotificationHandler<CategoryDeletedEvent>
    {
        private readonly IProductRepository productRepository;

        public CategoryDeletedEventHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Handle(CategoryDeletedEvent notification, CancellationToken cancellationToken)
        {

          List<Product> products = await  productRepository.GetProductsByCategoryId(notification.Id);

            foreach (var product in products)
            {
                product.CategoryRef = 0;
                await productRepository.SaveAsync();
                
            }
        }
    }
}
