using HESDashboard.Data;
using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class TagService : ITagService {
    private readonly HesDbContext _context;
    public TagService(HesDbContext context) => _context = context;
    public async Task CreateAsync(Tag tag) {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var tag = await _context.Tags.FindAsync(id);
        if (tag is not null) {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Tag>> GetAllAsync() {
        return await _context.Tags.OrderBy(t => t.Category).ThenBy(t => t.Name).ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(int id) {
        return await _context.Tags.FindAsync(id);
    }

    public async Task UpdateAsync(Tag tag) {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
    }
}
