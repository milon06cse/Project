using Forum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ForumUserController : Controller
    {
        //
        // GET: /ForumUser/

        public ActionResult Index()
        {
           // ForumUserModel model = new ForumUserModel();           
            return View(ForumUserModel.ShowAllUser());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(List<ForumUserModel> model)
        {
            //Validator.ValidateValue(model.Name,
            //Validator.TryValidateValue(model,.Required();
            ForumUserModel.Save(model[0]);
            return View(ForumUserModel.ShowAllUser());
        }
    }
}
