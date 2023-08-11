using AleyantPrint.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleyantPrint.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(string name);
        List<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(string name);
    }
}
