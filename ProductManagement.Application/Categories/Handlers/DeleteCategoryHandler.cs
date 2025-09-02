using MediatR;
using ProductManagement.Application.Categories.Commands;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Categories.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediator mediator;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository , IMediator mediator)
        {
            this.categoryRepository = categoryRepository;
            this.mediator = mediator;
        }
        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
          Category category =   await categoryRepository.DeleteAsync(request.Id);

           await mediator.Publish(new CategoryDeletedEvent() { Id = request.Id });
           return category;

        }
    }
}
