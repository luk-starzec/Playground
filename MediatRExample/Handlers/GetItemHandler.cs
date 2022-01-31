using MediatR;
using MediatRExample.Models;
using MediatRExample.Queries;
using MediatRExample.Repositories;

namespace MediatRExample.Handlers;

public class GetItemHandler : IRequestHandler<GetItemQuery, ItemModel>
{
    private readonly IItemsRepository repository;

    public GetItemHandler(IItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ItemModel> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetItemAsync(request.ItemId);
    }
}
