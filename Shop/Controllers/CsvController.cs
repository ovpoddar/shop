﻿using Microsoft.AspNetCore.Mvc;
using Shop.Managers;
using Shop.ViewModels;
using System;

namespace Shop.Controllers
{
    public class CsvController : Controller
    {
        private readonly ICsvManager _CsvManager;

        public CsvController(ICsvManager csvManager)
        {
            _CsvManager = csvManager ?? throw new ArgumentNullException(nameof(_CsvManager));
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CsvViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _CsvManager.Upload(model);
                if (result.Success)
                {
                    _CsvManager.Update(result.Path);
                    return View("//product/index");
                }
                else
                {
                    return View();
                }
            };
            return View();
        }
    }
}
