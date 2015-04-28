﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ForumThreadController : Controller
    {
        //
        // GET: /ForumThread/
        [HttpGet]
        public ActionResult Index(int id)
        {
            ForumThreadModel Thread = new ForumThreadModel();
            Thread.SectionId = id;
            return View("Index",Thread.ShowByParentId(Thread.SectionId).ToList());
          //  return View("ThreadsBySection", Thread.ShowByParentId(Thread.SectionId));
        }
        public ActionResult AddThread(string ThreadId)
        {
            return View(new ForumThreadModel());
        }
         [HttpPost]
        public ActionResult AddThread(ForumThreadModel model)
        {
            return View(new ForumThreadModel());
        }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Index(List<ForumThreadModel> model)
         {
             model[0].Save();
             return View("Index",new ForumThreadModel().ShowByParentId(model[0].SectionId).ToList());
         }

    }
}
