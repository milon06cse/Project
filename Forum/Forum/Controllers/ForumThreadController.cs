using Forum.Models;
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

        public ActionResult Index(int id)
        {
            ForumThreadModel Thread = new ForumThreadModel();
            return View("ThreadsBySection", Thread.ShowByParentId(id));
        }
        //[HttpPost]
        //public ActionResult Index(int SectionId)
        //{
        //    return View();
        //}

    }
}
