﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LPProject2.Controllers
{
    public class AdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAd()
        {
            return View("CreateAd");
        }
    }
}