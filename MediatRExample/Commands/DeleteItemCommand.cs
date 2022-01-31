using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Commands
{
    public class DeleteItemCommand : IRequest<CommandResult>
    {
        public Guid ItemId { get; }

        public DeleteItemCommand(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}
