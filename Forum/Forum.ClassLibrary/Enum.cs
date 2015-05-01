using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class Enum
    {
    }
        public enum SectionState
        {
            Open=1,
            Locked=2,
            AdminOnly=3,
            Delete=4
        }
        public enum ThreadState
        {
            Sticky = 1,
            Closed = 2
        }

}
