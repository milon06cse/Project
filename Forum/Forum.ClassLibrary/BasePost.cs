using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    abstract public class BasePost:ForumBase
    {
        public Guid ParentId { get; set; }
       // public Guid Id { get; set; }
       // public int DisplayOrder{get;set;}
        //public DateTime PostDate { get; set; }
        public int DownVoteCount { get; set; }
        public int UpVoteCount { get; set; }
        public int Score { get; set; }
        public BasePost()
        {
          //  PostDate = DateTime.Now;
            DownVoteCount = 0;
            UpVoteCount = 0;
            Score = 0;
          //  Id = Guid.NewGuid();
//ParentId = Guid.NewGuid();
        }
        public virtual int CalculateScore()
        {
            Score = UpVoteCount * 10 - DownVoteCount * 2;
            return Score < 0 ? 0 : Score;
        }
        public int IncrementUpVote()
        {
            return 1;
        }
        public int IncrementDownVote()
        {
            return 1;    
        }

    }
}
