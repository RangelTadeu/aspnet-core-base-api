using Microsoft.EntityFrameworkCore;

public class ItemRepository
{
    private readonly BaseDbContext _context;

    public ItemRepository(BaseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        var items = from i in _context.Items select i;

        return await items.ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
}
