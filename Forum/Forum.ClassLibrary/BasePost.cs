using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    abstract public class BasePost
    {
        public int ParentId;
        public int Id;
        public int DisplayOrder{get;set;}
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
        public int DownVoteCount { get; set; }
        public int UpVoteCount { get; set; }
        public int Score { get; set; }
        public virtual int CalculateScore()
        {
            Score = UpVoteCount * 10 - DownVoteCount * 2;
            return Score < 0 ? 0 : Score;
        }
        public int IncrementUpVote()
        {
            return 0;
        }
        public int IncrementDownVote()
        {
            return 0;    
        }

    }
}
