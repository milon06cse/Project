using Forum.ClassLibrary;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ForumSectionController : Controller
    {
        //
        // GET: /ForumSection/
        [HttpGet]
        public ActionResult Index()
        {
            ForumSectionModel model = new ForumSectionModel();
            return View(model.ShowFirstOne());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ForumSectionModel model)
        {
            model.Save();
            return View();
        }

    }
}
