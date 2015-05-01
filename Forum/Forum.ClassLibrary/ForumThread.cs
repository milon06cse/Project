using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class ForumThread:PrimaryPost
    {
        // public int ParentId { get; set; }
        public DateTime datetime { set; get; }
        List<ForumPost> Reply = new List<ForumPost>();
       // public  Guid Id { set; get; }
        
        public int TotalPostCount { set; get; }
        public string Title { set; get; }
        public bool AnswerStatus = false;
        public DateTime LastPoster { get; set; }
        public ForumThread()
        {
            //ParentId = Id;
        }
    }
}
