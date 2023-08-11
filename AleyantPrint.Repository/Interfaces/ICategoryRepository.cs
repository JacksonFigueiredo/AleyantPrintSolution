using AleyantPrint.Domain.Models;

namespace AleyantPrint.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(string name);
    }
}
