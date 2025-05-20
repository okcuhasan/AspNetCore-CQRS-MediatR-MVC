using MediatR;

namespace CQRSSample_0.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public int ID { get; set; }
        public RemoveCategoryCommand(int id)
        {
            ID = id;
        }
    }
}
