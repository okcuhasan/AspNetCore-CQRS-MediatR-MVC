using CQRSSample_0.CQRS.Queries.CategoryQueries;
using CQRSSample_0.CQRS.Results.CategoryResults;
using CQRSSample_0.Models.Entities;
using CQRSSample_0.Repositories.Abstracts;
using MediatR;

namespace CQRSSample_0.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIDQueryHandler : IRequestHandler<GetCategoryByIDQuery, GetCategoryByIDQueryResult>
    {
        readonly IRepository<Category> _repository;
        public GetCategoryByIDQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIDQueryResult> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.ID);
            GetCategoryByIDQueryResult result = new()
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName,
                Description = value.Description
            };

            return result;
        }
    }
}
