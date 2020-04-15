﻿using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using Shop.Models;
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

        public CategorieModel AddCategory(CategoryViewModel model)
        {
            if (_repository.GetAll().Any(category => category.Name.ToUpper() == model.Name.ToUpper() && 
                                                     category.ParentId == model.Id) ||
                                                     string.IsNullOrWhiteSpace(model.Name))
                return new CategorieModel
                {
                    All = _repository.GetAll().ToList(),
                    Success = false
                };

            _repository.Add(new Category
            {
                ParentId = model.Id,
                Name = model.Name
            });

            _repository.save();

            return new CategorieModel
            {
                All = _repository.GetAll().ToList(),
                Success = true
            };
        }

        public List<Category> Categories() =>
            _repository.GetAll().Where(category => category.ParentId == null)
                .Include(p => p.SubCategories).ToList();

        public List<Category> GetAll() => _repository.GetAll().ToList();

        public int GetId(string name) =>
            _repository.GetAll()
            .Where(o => o.Name.ToUpper() ==  name.ToUpper())
            .Select(o => o.Id)
            .FirstOrDefault();
    }
}
