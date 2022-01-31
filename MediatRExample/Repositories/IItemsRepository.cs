using MediatRExample.Models;

namespace MediatRExample.Repositories;

public interface IItemsRepository
{
    Task<List<ItemModel>> GetAllItemsAsync();
    Task<ItemModel> GetItemAsync(Guid id);
    Task<ItemModel> CreateItemAsync(CreateItemModel model);
    Task<CommandResult> UpdateItemAsync(Guid id, UpdateItemModel model);
    Task<CommandResult> DeleteItemAsync(Guid id);
}
