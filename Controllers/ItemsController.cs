using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_base_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ItemRepository _repository;

    public ItemsController(ItemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _repository.GetItemsAsync();
    }

    [HttpGet("{id}")]
    public async Task<Item> GetItemByIdAsync(int id)
    {
        return await _repository.GetItemByIdAsync(id);
    }

    [HttpPost]
    public async Task<Item> CreateItemAsync(Item item)
    {
        return await _repository.CreateItemAsync(item);
    }

    [HttpPut("{id}")]
    public async Task<Item> UpdateItemAsync(int id, Item item)
    {
        if (id != item.Id)
        {
            throw new BadHttpRequestException("Id mismatch");
        }

        return await _repository.UpdateItemAsync(item);
    }

    [HttpDelete("{id}")]
    public async Task DeleteItemAsync(int id)
    {
        await _repository.DeleteItemAsync(id);
    }
}
