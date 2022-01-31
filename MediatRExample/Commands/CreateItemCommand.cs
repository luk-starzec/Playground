using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Commands
{
    public class CreateItemCommand : IRequest<ItemModel>
    {
        public CreateItemModel Item { get; }

        public CreateItemCommand(CreateItemModel item)
        {
            Item = item;
        }
    }
}
