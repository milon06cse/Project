using Forum.ClassLibrary;
using Forum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumThreadModel
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public ForumThreadModel ShowByParentId(int SectionId)
        {
            ForumThreadModel model = new ForumThreadModel();
            ForumThread thread = new ForumThread();
            ForumThreadRepository repository = new ForumThreadRepository();
           thread= repository.ShowBySectionId(SectionId);
            model.Title = thread.Title;
            model.ThreadId = thread.ThreadId;
            return model;
        }
    }
}