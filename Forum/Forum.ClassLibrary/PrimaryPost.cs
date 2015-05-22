using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class PrimaryPost:BasePost
    {
        public bool IsFavourite { set; get; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
