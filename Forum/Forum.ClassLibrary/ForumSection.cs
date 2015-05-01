using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class ForumSection:ForumBase
    {        
        public string Name { get; set; }
        public SectionState State;
        public int DisplayOrder { get; set; }
       // public List<ForumThread> Threads = new List<ForumThread>();
       // private ForumSection _Section;
       public ForumSection()
        {
            Name = string.Empty;
            DisplayOrder = 0;
            State = SectionState.Open;
        }
    }
}
