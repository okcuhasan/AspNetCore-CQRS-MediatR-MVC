using MediatR;

namespace CQRSSample_0.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; } 
    }
}
