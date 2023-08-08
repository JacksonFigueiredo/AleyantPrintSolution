using AleyantPrint.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AleyantPrint.API.Data
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }
    }
}
