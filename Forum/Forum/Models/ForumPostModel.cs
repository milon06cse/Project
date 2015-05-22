using Forum.ClassLibrary;
using Forum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumPostModel : ForumPost
    {
        public ForumPostModel()
        {           
        }
       // public ForumThreadModel Thread = new ForumThreadModel();
        public List<ForumPostModel> ShowByParentId(Guid ParentId)
        {
            List<ForumPostModel> items = new List<ForumPostModel>();
            ForumPostRepository repository = new ForumPostRepository();
            List<ForumPost> posts = repository.PostsByThreadId(ParentId);
            foreach (ForumPost item in posts)
            {
                ForumPostModel model = new ForumPostModel();
                model.ParentId = ParentId;
              //  model.Title = item.Title;
                model.Id = item.Id;
                model.PostText = item.PostText;
                items.Add(model);
            }
            if (items.Count == 0)
            {
                ForumPostModel model = new ForumPostModel();
                model.ParentId = ParentId;
                items.Add(model);
            }

           // Thread = Thread.ThreadByThreadId(ParentId);
            
            return items;
        }

        internal bool Save(Guid ParentId)
        {
            ForumPost Post = new ForumPost();
            ForumPostRepository repository = new ForumPostRepository();
            Post.ParentId = ParentId;
            Post.Id = Guid.NewGuid();// repository.MaxColumnValue("Id", "Thread");
           // Thread.Title = Title;
            Post.PostText = PostText;
            return repository.Add(Post);
        }
    }
}