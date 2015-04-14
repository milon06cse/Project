using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.ClassLibrary
{
    public class ForumSection:ForumBase
    {
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public EnumSectionState SectionState;
        public int SectionDisplayOrder { get; set; }
        private ForumSection _Section;
        ForumSection(ForumSection Section)
        {
            _Section.SectionNumber = 0;
            _Section.SectionName = string.Empty;
            _Section.SectionDisplayOrder = 0;
            _Section = Section;
        }
    }
}
