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
        //public int ThreadId { get; set; }
        public string Title { get; set; }
       // public Guid Id { get; set; }
        public ForumThreadModel()
        {
            Title = string.Empty;

        }
        public List<ForumThreadModel> ShowByParentId(Guid Id)
        {
            List<ForumThreadModel> items = new List<ForumThreadModel>();   
            ForumThreadRepository repository = new ForumThreadRepository();
          List<ForumThread> threads= repository.ShowBySectionId(Id);
           foreach (ForumThread item in threads)
           {
               ForumThreadModel model = new ForumThreadModel();
               model.Id = Id;
               model.Title = item.Title;
               model.Id = item.Id;
               model.PostText = item.PostText;
               items.Add(model);
           }
           if (items.Count == 0)
           {
               ForumThreadModel model = new ForumThreadModel();
               model.Id = Id;
               items.Add(model);
           }
            return items;
        }

        internal bool Save()
        {
            ForumThread Thread = new ForumThread();
            ForumThreadRepository repository = new ForumThreadRepository();
            Thread.ParentId = Id;
            Thread.Id = Guid.NewGuid();// repository.MaxColumnValue("Id", "Thread");
            Thread.Title = Title;
            Thread.PostText = PostText;
          return  repository.Add(Thread);
        }
    }
}