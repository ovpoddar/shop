﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Handlers.Interfaces;

namespace Shop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IValidatorHandler _validatorHandler;

        public CheckoutController(IValidatorHandler validatorHandler)
        {
            _validatorHandler = validatorHandler ?? throw new ArgumentNullException(nameof(_validatorHandler));
        }
        public async Task<IActionResult> IndexAsync()
        {
            if (await _validatorHandler.IsMember())
                return View();
            return RedirectToActionPermanent("LogIn", "Authentication", new { con = ControllerContext.RouteData.Values["controller"].ToString(), ac = ControllerContext.RouteData.Values["action"].ToString() });
        }
    }
}