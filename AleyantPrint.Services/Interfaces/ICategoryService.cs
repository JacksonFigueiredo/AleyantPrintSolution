using AleyantPrint.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleyantPrint.Services.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategory(string name);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(string name);
    }
}
