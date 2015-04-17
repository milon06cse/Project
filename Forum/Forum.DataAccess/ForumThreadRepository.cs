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
    public class ForumThreadRepository:BaseRepository
    {
        public bool Add(ForumThread Thread)
        {
            try
            {
                OpenConnection();
                DbCommand Command = CreateSqlCommand("insert into ForumSection(SectionId,SectionName,DisplayOrder) values(@SectionId,@SectionName,@DisplayOrder)");
                Command.Parameters.Add(CreateParameter("SectionId", Thread.ParentId));
                Command.Parameters.Add(CreateParameter("Title", Thread.Title));
                Command.Parameters.Add(CreateParameter("ThreadId", Thread.ThreadId));
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
        public bool Edit(ForumThread Thread)
        {
            return false;
        }
        public bool Delete(ForumThread Thread)
        {
            return false;
        }
        public ForumThread ShowBySectionId(int sectionid)
        {
            ForumThread Thread = new ForumThread();
            string sql = string.Empty;
            sql =string.Format("select *from ForumThread where SectionId='{0}'",sectionid);
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Thread.ParentId = sectionid;
                Thread.Title = reader["Title"].ToString();
                Thread.ThreadId = Convert.ToInt32(reader["ThreadId"]);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();

            return  Thread;
        }
        public List<ForumThread> ShowAll()
        {
            List<ForumThread> Threads = new List<ForumThread>();
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
                ForumThread Thread = new ForumThread();
                //item.SectionId = Convert.ToInt32(reader["SectionId"]);
                //item.SectionName = reader["SectionName"].ToString();
                //item.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                //Sections.Add(item);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();
            return Threads;
        }
    }
}
