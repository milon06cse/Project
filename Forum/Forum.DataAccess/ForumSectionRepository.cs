using Forum.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess
{
    public class ForumSectionRepository:BaseRepository
    {
        public bool Add(ForumSection Section)
        {
            try
            {
                OpenConnection();
                DbCommand Command = CreateSqlCommand("insert into ForumSection(SectionId,SectionName,DisplayOrder) values(@SectionId,@SectionName,@DisplayOrder)");
                Command.Parameters.Add(CreateParameter("SectionId", Section.SectionId));
                Command.Parameters.Add(CreateParameter("SectionName", Section.SectionName));
                Command.Parameters.Add(CreateParameter("DisplayOrder", Section.DisplayOrder));
                Command.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch
            {
                CloseConnection();
                return false;
            }
        }
        public bool Edit(ForumSection Section)
        {
            return false;
        }
        public bool Delete(ForumSection Section)
        {
            return false;
        }
        public ForumSection ShowBySectionId()
        {
            ForumSection Section = new ForumSection();

            return Section;
        }
        public List<ForumSection> ShowAll()
        {
            List<ForumSection> Sections = new List<ForumSection>();

            return Sections;
        }
    }
}
