using AleyantPrint.Domain.Models;
using AleyantPrint.Repository.Interfaces;
using AleyantPrint.Services.Interfaces;
using AleyantPrint.Services.Services;
using Moq;

namespace AleyantPrint.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _mockRepository;
        private readonly ICategoryService _categoryService;

        public CategoryServiceTests()
        {
            _mockRepository = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(_mockRepository.Object);
        }

        [Fact]
        public void AddCategory_WithExistingName_ThrowsException()
        {
            var category = new Category { Name = "Test", ParentName = null };
            _mockRepository.Setup(r => r.Get(category.Name)).Returns(category);

            Assert.Throws<ArgumentException>(() => _categoryService.AddCategory(category));
        }

        [Fact]
        public void AddCategory_WithDepthExceedingLimit_ThrowsException()
        {
            var parent = new Category { Name = "Parent", ParentName = null };
            var child = new Category { Name = "Child", ParentName = "Parent" };

            _mockRepository.Setup(r => r.Get(parent.Name)).Returns(parent);
            _mockRepository.Setup(r => r.Get(child.ParentName)).Returns(child);

            for (int i = 0; i < 10; i++)
            {
                var newChild = new Category { Name = "Child" + i, ParentName = child.Name };
                _mockRepository.Setup(r => r.Get(newChild.Name)).Returns(newChild);
                child = newChild;
            }

            Assert.Throws<ArgumentException>(() => _categoryService.AddCategory(new Category { Name = "TooDeep", ParentName = child.Name }));
        }
    }
}