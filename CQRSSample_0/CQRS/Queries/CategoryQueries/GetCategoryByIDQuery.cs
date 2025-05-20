using CQRSSample_0.CQRS.Results.CategoryResults;
using MediatR;

namespace CQRSSample_0.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIDQuery : IRequest<GetCategoryByIDQueryResult>
    {
        public int ID { get; set; }
        public GetCategoryByIDQuery(int id)
        {
            ID = id;
        }
    }
}
