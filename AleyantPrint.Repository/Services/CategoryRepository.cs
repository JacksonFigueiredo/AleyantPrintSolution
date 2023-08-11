﻿using AleyantPrint.API.Data;
using AleyantPrint.Domain.Models;
using AleyantPrint.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AleyantPrint.Repository.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }

        public Category Get(string name)
        {
            return _context.Categories.Include(c => c.Children).FirstOrDefault(c => c.Name == name);
        }
      

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(string name)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name == name);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
