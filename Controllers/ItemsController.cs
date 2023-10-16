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

    [HttpPost]
    public async Task<Item> CreateItemAsync(Item item)
    {
        return await _repository.CreateItemAsync(item);
    }
}
