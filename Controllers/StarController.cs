﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StarController : Controller
    {
        // GET: Star
        public ActionResult Index()
        {
            Star obj = new Star();
            obj.magnex();
            return View();
        }
    }
}