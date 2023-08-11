using AleyantPrint.Domain.Models;

namespace AleyantPrint.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(string name);
        Task<List<Category>> GetAllCategoryAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(string name);
    }
}
