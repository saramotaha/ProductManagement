using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ICategoryRepository categoryRepository;

        public ProductCreatedEventHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            if (notification.CategoryId.HasValue)
            {
                var categoryExists = await categoryRepository.CategoryExists(notification.CategoryId.Value);
                if (!categoryExists)
                    throw new Exception("Category not found");
            }
        }
    }
}
