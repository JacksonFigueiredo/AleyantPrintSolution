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
    }
}