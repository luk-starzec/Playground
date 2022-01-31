using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Queries
{
    public class GetItemQuery : IRequest<ItemModel>
    {
        public Guid ItemId { get; }

        public GetItemQuery(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}
