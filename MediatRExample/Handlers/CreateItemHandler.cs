using MediatR;
using MediatRExample.Commands;
using MediatRExample.Models;
using MediatRExample.Repositories;

namespace MediatRExample.Handlers;

public class CreateItemHandler : IRequestHandler<CreateItemCommand, ItemModel>
{
    private readonly IItemsRepository repository;

    public CreateItemHandler(IItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ItemModel> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        return await repository.CreateItemAsync(request.Item);
    }
}
