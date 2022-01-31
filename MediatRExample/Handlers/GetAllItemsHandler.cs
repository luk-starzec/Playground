using MediatR;
using MediatRExample.Models;
using MediatRExample.Queries;
using MediatRExample.Repositories;

namespace MediatRExample.Handlers;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, List<ItemModel>>
{
    private readonly IItemsRepository repository;

    public GetAllItemsHandler(IItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<ItemModel>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllItemsAsync();
    }
}
