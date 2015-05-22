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
        public List<ForumPostModel> Posts = new List<ForumPostModel>();
       // public Guid Id { get; set; }
        public string Comment { get; set; }
        public ForumThreadModel()
        {
            Comment = string.Empty; 
        }
        public ForumThreadModel ThreadByThreadId(Guid ThreadId)
        {
            ForumThreadRepository repository = new ForumThreadRepository();
            ForumThread thread = repository.ThreadByThreadId(ThreadId);
            
                ForumThreadModel model = new ForumThreadModel();
               // model.ParentId = thread.ParentId;
                model.Title = thread.Title;
                model.Id = thread.Id;
                model.Description = thread.Description;
            return model;
        }
        public List<ForumThreadModel> ShowByParentId(Guid ParentId)
        {
            List<ForumThreadModel> items = new List<ForumThreadModel>();   
            ForumThreadRepository repository = new ForumThreadRepository();
            List<ForumThread> threads = repository.ThreadsBySectionId(ParentId);
           foreach (ForumThread item in threads)
           {
               ForumThreadModel model = new ForumThreadModel();
               model.ParentId = ParentId;
               model.Title = item.Title;
               model.Id = item.Id;
               model.Description = item.Description;
               items.Add(model);
           }
           if (items.Count == 0)
           {
               ForumThreadModel model = new ForumThreadModel();
               model.ParentId = ParentId;
               items.Add(model);
           }
            return items;
        }

        internal bool Save(Guid ParentId)
        {
            ForumThread Thread = new ForumThread();
            ForumThreadRepository repository = new ForumThreadRepository();
            Thread.ParentId = ParentId;
            Thread.Id = Guid.NewGuid();// repository.MaxColumnValue("Id", "Thread");
            Thread.Title = Title;
            Thread.Description = Description;
          return  repository.Add(Thread);
        }
        public ForumThreadModel ThreadWithPosts(Guid ThreadId)
        {
            ForumThreadModel Thread = new ForumThreadModel();
            //creating thread as header
            Thread = ThreadByThreadId(ThreadId);
            //creating posts            
            ForumPostRepository repo=new ForumPostRepository();
            List<ForumPost> baseposts = new List<ForumPost>();
            baseposts=repo.PostsByThreadId(ThreadId);
           foreach(ForumPost citem in baseposts)
           {
               ForumPostModel mitem=new ForumPostModel();
               mitem.Id=citem.Id;
               mitem.ParentId = citem.ParentId;
               mitem.PostText = citem.PostText;
               mitem.CreationDate = citem.CreationDate;
                Thread.Posts.Add(mitem);
           }
            return Thread;
        }
    }
}