﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
   public  class ForumPost:BasePost
    {
       public bool CorrectAnswer { set; get; }
       public string PostText { get; set; }
       public override int CalculateScore()
       {
           Score = UpVoteCount * 10 - DownVoteCount * 2;
           if (CorrectAnswer) Score = Score + 100;
           return Score < 0 ? 0 : Score;
       }
       public ForumPost()
       {
           CorrectAnswer = false;
           PostText = string.Empty;
       }
       public ForumPost ShowPost(ForumPost item)
       {
           item.PostText = this.PostText;
           return item;
       }
    }
}
