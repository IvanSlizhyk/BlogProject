﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        [HttpGet]
        public ActionResult CreateComment()
        {
            return View();
        }

    }
}