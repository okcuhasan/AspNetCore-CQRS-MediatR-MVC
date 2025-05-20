using CQRSSample_0.CQRS.Commands.CategoryCommands;
using CQRSSample_0.Models.Entities;
using CQRSSample_0.Repositories.Abstracts;
using MediatR;

namespace CQRSSample_0.CQRS.Handlers.CategoryHandlers.Modify
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        readonly IRepository<Category> _repository;
        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description
            };

            await _repository.CreateAsync(category);
        }
    }
}
