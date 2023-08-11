using AleyantPrint.Domain.Models;
using AleyantPrint.Repository.Interfaces;
using AleyantPrint.Services.Interfaces;

namespace AleyantPrint.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category GetCategory(string name)
        {
            return _repository.Get(name);
        }

        public List<Category> GetAllCategory()
        {
            return _repository.GetAll();
        }

        public void AddCategory(Category category)
        {
            ValidateCategory(category);
            _repository.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            ValidateCategory(category);
            _repository.Update(category);
        }

        public void DeleteCategory(string name)
        {
            _repository.Delete(name);
        }

        private void ValidateCategory(Category category)
        {
            if (_repository.Get(category.Name) != null)
                throw new ArgumentException($"Category with the name {category.Name} already exists.");

            if (!string.IsNullOrEmpty(category.ParentName))
            {
                var parentCategory = _repository.Get(category.ParentName);
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
                depth++;
                current = _repository.Get(current.ParentName);
            }

            return depth;
        }
    }
}
