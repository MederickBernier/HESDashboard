using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface ITagService {
    Task<List<Tag>> GetAllAsync();
    Task<Tag?> GetByIdAsync(int id);
    Task CreateAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(int id);
}
