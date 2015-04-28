using Forum.ClassLibrary;
using Forum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumThreadModel:PrimaryPost
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public int SectionId { get; set; }
        public List<ForumThreadModel> ShowByParentId(int SectionId)
        {
            List<ForumThreadModel> items = new List<ForumThreadModel>();   
            ForumThreadRepository repository = new ForumThreadRepository();
          List<ForumThread> threads= repository.ShowBySectionId(SectionId);
           foreach (ForumThread item in threads)
           {
               ForumThreadModel model = new ForumThreadModel();
               model.SectionId = SectionId;
               model.Title = item.Title;
               model.ThreadId = item.ThreadId;
               model.PostText = item.PostText;
               items.Add(model);
           }
            return items;
        }

        internal bool Save()
        {
            ForumThread Thread = new ForumThread();
            ForumThreadRepository repository = new ForumThreadRepository();
            Thread.ParentId = SectionId;
            Thread.ThreadId = repository.MaxColumnValue("ThreadId", "ForumThread");
            Thread.Title = Title;
            Thread.PostText = PostText;
          return  repository.Add(Thread);
        }
    }
}