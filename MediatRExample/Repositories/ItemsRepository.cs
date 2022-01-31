using MediatRExample.Models;

namespace MediatRExample.Repositories;

public class ItemsRepository : IItemsRepository
{
    private readonly List<ItemModel> items = new();

    public async Task<ItemModel> CreateItemAsync(CreateItemModel model)
    {
        var item = new ItemModel
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            Created = DateTime.Now,
        };
        items.Add(item);
        return await Task.FromResult(item);
    }

    public async Task<CommandResult> DeleteItemAsync(Guid id)
    {
        var item = items.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return new CommandResult(false);

        items.Remove(item);

        return await Task.FromResult(new CommandResult(true));
    }

    public async Task<ItemModel> GetItemAsync(Guid id)
    {
        var result = items.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(result);
    }

    public async Task<List<ItemModel>> GetAllItemsAsync()
    {
        return await Task.FromResult(items.ToList());
    }

    public async Task<CommandResult> UpdateItemAsync(Guid id, UpdateItemModel model)
    {
        var item = await GetItemAsync(id);

        if (item is null)
            return new CommandResult(false);

        item.Name = model.Name;
        item.Description = model.Description;

        return await Task.FromResult(new CommandResult(true));
    }
}
