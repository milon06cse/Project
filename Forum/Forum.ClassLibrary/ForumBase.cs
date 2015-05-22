using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class ForumBase
    {

        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid Id { get; set; }
       public ForumBase()
        {
            UserId =new Guid("59ef2601-e4e4-423e-8bb7-d5b1d589f028");
            CreationDate = DateTime.Now;
            Id = Guid.Empty;
        }
    }
}
