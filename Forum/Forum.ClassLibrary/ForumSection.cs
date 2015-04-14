using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ClassLibrary
{
    public class ForumSection:ForumBase
    {
        public int SectionId { get; set; } //Guid use korte hobe
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public EnumSectionState SectionState;
        public int DisplayOrder { get; set; }
        public List<ForumThread> Threads = new List<ForumThread>();
        private ForumSection _Section;
        //ForumSection(ForumSection Section)
        //{
        //    _Section.SectionNumber = 0;
        //    _Section.SectionName = string.Empty;
        //    _Section.SectionDisplayOrder = 0;
        //    _Section = Section;
        //}
    }
}
