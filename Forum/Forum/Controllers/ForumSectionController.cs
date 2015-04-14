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

        public ActionResult Index()
        {
            return View();
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
