using System.Data;
using aspnet_core_base_api.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
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
        var col = from i in _context.Items select i;

        return await col.ToListAsync();
    }

    public async Task<Item> GetItemByIdAsync(int id)
    {
        var queryResult = from i in _context.Items where i.Id == id select i;

        var entity = await queryResult.FirstOrDefaultAsync();

        if (entity == null)
        {
            throw new NotFoundException($"Entity with id {id} not found");
        }

        return entity;
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Item> UpdateItemAsync(Item item)
    {
        try
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(item.Id))
            {
                throw new NotFoundException($"Entity with id {item.Id} not found");
            }
            else
            {
                throw;
            }
        }

        return item;
    }

    public async Task<Item> DeleteItemAsync(int id)
    {
        var entity = await GetItemByIdAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    private bool ItemExists(int id)
    {
        return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
