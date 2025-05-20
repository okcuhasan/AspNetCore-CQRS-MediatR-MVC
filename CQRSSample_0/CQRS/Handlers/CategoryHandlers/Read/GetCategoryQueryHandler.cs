using CQRSSample_0.CQRS.Queries.CategoryQueries;
using CQRSSample_0.CQRS.Results.CategoryResults;
using CQRSSample_0.Models.Entities;
using CQRSSample_0.Repositories.Abstracts;
using MediatR;

namespace CQRSSample_0.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        readonly IRepository<Category> _repository;
        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await _repository.GetAllAsync();
            List<GetCategoryQueryResult> values = categories.Select(c => new GetCategoryQueryResult
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToList();

            return values;
        }
    }
}
