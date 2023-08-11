using AleyantPrint.Domain.Models;

namespace AleyantPrint.Services.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategory(string name);
        List<Category> GetAllCategory();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(string name);
    }
}
