using CQRSSample_0.CQRS.Commands.CategoryCommands;
using CQRSSample_0.Models.Entities;
using CQRSSample_0.Repositories.Abstracts;
using MediatR;

namespace CQRSSample_0.CQRS.Handlers.CategoryHandlers.Modify
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        readonly IRepository<Category> _repository;
        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.ID);
            await _repository.RemoveAsync(value);
        }
    }
}
