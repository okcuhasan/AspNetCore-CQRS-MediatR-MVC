using CQRSSample_0.CQRS.Results.CategoryResults;
using MediatR;

namespace CQRSSample_0.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}
