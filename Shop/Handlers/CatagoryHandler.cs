﻿using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using Shop.Repositories;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Handlers
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryHandler(IGenericRepository<Category> repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public List<Category> AddCategory(CategoryViewModel model)
        {
            if (_repository.GetAll().Any(category => category.Name.ToLower() == model.Name.ToLower() && category.ParentId == model.Id) || model.Name == "")
                return _repository.GetAll().ToList();

            _repository.Add(new Category
            {
                ParentId = model.Id,
                Name = model.Name
            });
            _repository.save();
            return GetAll();
        }

        public List<Category> Categories() =>
            _repository.GetAll().Where(category => category.ParentId == null)
                .Include(p => p.SubCategories).ToList();

        public List<Category> GetAll() => _repository.GetAll().ToList();

        public int GetId(string Name) =>
            _repository.GetAll()
            .Where(o => o.Name.ToLower() == Name.ToLower())
            .Select(o => o.Id)
            .FirstOrDefault();
    }
}
