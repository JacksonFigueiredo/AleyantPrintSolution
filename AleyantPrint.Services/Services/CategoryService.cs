using AleyantPrint.Domain.Models;
using AleyantPrint.Repository.Interfaces;
using AleyantPrint.Services.Interfaces;

namespace AleyantPrint.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> GetCategoryAsync(string name)
        {
            return await _repository.GetAsync(name); // Assuming the method in _repository is named GetAsync.
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddCategoryAsync(Category category)
        {
            ValidateCategory(category);
            await _repository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            ValidateCategory(category);
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(string name)
        {
            await _repository.DeleteAsync(name);
        }

        private void ValidateCategory(Category category)
        {
            if (_repository.GetAsync(category.Name).Result != null)
                throw new ArgumentException($"Category with the name {category.Name} already exists.");

            if (!string.IsNullOrEmpty(category.ParentName))
            {
                var parentCategory = _repository.GetAsync(category.ParentName).Result;
                if (parentCategory == null)
                    throw new ArgumentException($"Parent category {category.ParentName} does not exist.");

                var depth = GetDepth(parentCategory);
                if (depth >= 10)
                    throw new ArgumentException($"Category hierarchy cannot exceed 10 levels. Current depth is {depth}.");
            }
        }

        private int GetDepth(Category category)
        {
            int depth = 0;
            var current = category;

            while (current != null)
            {
                _rwLock.EnterReadLock();
                try
                {
                    current = _repository.GetAsync(current.ParentName).Result; // Blocking call! Might consider rethinking for better asynchronicity.
                }
                finally
                {
                    _rwLock.ExitReadLock();
                }
                depth++;
            }

            return depth;
        }
    }
}
