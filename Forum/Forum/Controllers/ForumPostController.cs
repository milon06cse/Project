using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ForumPostController : Controller
    {
        //
        // GET: /ForumPost/
        [HttpGet]
        public ActionResult Index(Guid Id)
        {
            ForumThreadModel thread = new ForumThreadModel();
            thread.Id = Id;
            return View("Index", thread.ThreadWithPosts(thread.Id));
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Index(ForumThreadModel thread)
        {
            ForumPostModel newpost = new ForumPostModel();
            newpost.PostText = thread.Comment;
            newpost.Save(thread.Id);
            return View("Index", thread.ThreadWithPosts(thread.Id));
        }           
    }
}
