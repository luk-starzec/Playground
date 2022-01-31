using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Commands
{
    public class UpdateItemCommand : IRequest<CommandResult>
    {
        public Guid ItemId { get; set; }
        public UpdateItemModel Item { get; set; }
    }
}
