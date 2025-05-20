using CQRSSample_0.CQRS.Commands.CategoryCommands;
using CQRSSample_0.Models.Entities;
using CQRSSample_0.Repositories.Abstracts;
using MediatR;

namespace CQRSSample_0.CQRS.Handlers.CategoryHandlers.Modify
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        readonly IRepository<Category> _repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.CategoryID);
            value.CategoryName = request.CategoryName;
            value.Description = request.Description;

            await _repository.UpdateAsync(value);
        }
    }
}
