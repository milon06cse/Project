using Forum.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
        public ForumSection ShowFirstSection()
        {
            ForumSection Section = new ForumSection();
            string sql = string.Empty;
            sql = "select *from ForumSection where DisplayOrder='1'";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Section.SectionId = Convert.ToInt32(reader["SectionId"]);
                Section.SectionName = reader["SectionName"].ToString();
                Section.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();
            
            return Section;
        }
        public List<ForumSection> ShowAll()
        {
            List<ForumSection> Sections = new List<ForumSection>();
            string sql = string.Empty;
            sql = "select *from ForumSection order by DisplayOrder";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumSection item = new ForumSection();
                item.SectionId = Convert.ToInt32(reader["SectionId"]);
                item.SectionName = reader["SectionName"].ToString();
                item.DisplayOrder = Convert.ToInt32( reader["DisplayOrder"]);
                Sections.Add(item);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();
            return Sections;
        }
    }
}
