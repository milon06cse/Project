using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ClassA:IClassA
    {

        public int Duration
        {
            get;
            set;
        }

        public void start()
        {         
          // MessageBox.Show("Started");
        }
    }
}