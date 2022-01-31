using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Queries
{
    public class GetAllItemsQuery : IRequest<List<ItemModel>>
    {
    }
}
