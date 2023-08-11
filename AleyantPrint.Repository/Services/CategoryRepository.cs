using AleyantPrint.API.Data;
using AleyantPrint.Domain.Models;
using AleyantPrint.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AleyantPrint.Repository.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }

        public async Task<Category> GetAsync(string name)
        {
            return await _context.Categories.Include(c => c.Children).FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
