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
                DbCommand Command = CreateSqlCommand("insert into ForumThread(SectionId,Title,ThreadId,PostText) values(@SectionId,@Title,@ThreadId,@PostText)");
                Command.Parameters.Add(CreateParameter("SectionId", Thread.ParentId));
                Command.Parameters.Add(CreateParameter("Title", Thread.Title));
                Command.Parameters.Add(CreateParameter("ThreadId", Thread.ThreadId));
                Command.Parameters.Add(CreateParameter("PostText", Thread.PostText));
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
        public List<ForumThread> ShowBySectionId(int sectionid)
        {
            List<ForumThread> Threads = new List<ForumThread>();
            ForumThread Thread = new ForumThread();
            string sql = string.Empty;
            sql ="select *from ForumThread where SectionId=@SectionId";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Parameters.Add(CreateParameter("SectionId", sectionid));
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thread.ParentId = sectionid;
                Thread.Title = reader["Title"].ToString();
                Thread.ThreadId = Convert.ToInt32(reader["ThreadId"]);
                Thread.PostText = reader["PostText"].ToString();
                Threads.Add(Thread);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();

            return  Threads;
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
