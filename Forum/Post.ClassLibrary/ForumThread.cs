using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.ClassLibrary
{
    public class ForumThread:ForumBase
    {
        public PrimaryPost MainPost = new PrimaryPost();
        
        List<ForumPost> Reply = new List<ForumPost>();        
        
        public int TotalPostCount { set; get; }
        public string Title { set; get; }
        public bool AnswerStatus = false;
        public DateTime LastPoster { get; set; }
    }
}
