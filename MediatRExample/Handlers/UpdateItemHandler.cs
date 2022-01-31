using MediatR;
using MediatRExample.Commands;
using MediatRExample.Models;
using MediatRExample.Repositories;

namespace MediatRExample.Handlers;

public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, CommandResult>
{
    private readonly IItemsRepository repository;

    public UpdateItemHandler(IItemsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<CommandResult> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        return await repository.UpdateItemAsync(request.ItemId, request.Item);
    }
}
