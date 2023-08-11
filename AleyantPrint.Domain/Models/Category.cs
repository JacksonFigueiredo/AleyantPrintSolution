namespace AleyantPrint.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ParentName { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();
    }

}
