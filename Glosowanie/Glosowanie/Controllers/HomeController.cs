﻿using Glosowanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glosowanie.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Token model)
        {
            if (true)
            {
                //TO DO
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreatePool()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePool(Token model)
        {
            return View();
        }
    }
}