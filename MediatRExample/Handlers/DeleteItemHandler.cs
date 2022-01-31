using MediatR;
using MediatRExample.Commands;
using MediatRExample.Models;
using MediatRExample.Repositories;

namespace MediatRExample.Handlers;

public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, CommandResult>
{
    private readonly IItemsRepository repository;

    public DeleteItemHandler(IItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<CommandResult> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        return await repository.DeleteItemAsync(request.ItemId);
    }
}
