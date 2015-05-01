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
            return View(model.Show());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(List<ForumSectionModel> model)
        {
            model[0].Save();
            return View(model[0].Show());
        }
        [HttpGet]
        public ActionResult ViewSections()
        {
            ForumSectionModel model = new ForumSectionModel();
            return View(model.Show());
        }
        [HttpPost]
        public ActionResult ViewSections(ForumSectionModel model)
        {
            ForumSection section = new ForumSection();
            section.Name=model.Name;
            return View(model.Show());
        }
    }
}
