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
                DbCommand Command = CreateSqlCommand("insert into Thread(Id,Title,SectionId,Description,CreationDate,UserId) values(@Id,@Title,@SectionId,@Description,@CreationDate,@UserId)");
                Command.Parameters.Add(CreateParameter("SectionId", Thread.ParentId));
                Command.Parameters.Add(CreateParameter("Title", Thread.Title));
                Command.Parameters.Add(CreateParameter("Id", Thread.Id));
                Command.Parameters.Add(CreateParameter("Description", Thread.Description));
                Command.Parameters.Add(CreateParameter("CreationDate", DateTime.Now));
                Command.Parameters.Add(CreateParameter("UserId", Thread.UserId));
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

        public ForumThread ThreadByThreadId(Guid ThreadId)
        {
            string sql = string.Empty;
            sql = "select *from Thread where Id=@ThreadId";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Parameters.Add(CreateParameter("ThreadId", ThreadId));
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
                ForumThread Thread = new ForumThread();
                if (reader.Read())
                {
                   // Thread.ParentId = ThreadId;
                    Thread.Title = reader["Title"].ToString();
                    Thread.Id = (Guid)reader["Id"];
                    Thread.Description = reader["Description"].ToString();
                }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();

            return Thread;
        }
        public List<ForumThread> ThreadsBySectionId(Guid ParentId)
        {
            List<ForumThread> Threads = new List<ForumThread>();
            string sql = string.Empty;
            sql ="select *from Thread where SectionId=@SectionId";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Parameters.Add(CreateParameter("SectionId", ParentId));
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumThread Thread = new ForumThread();
                Thread.ParentId = ParentId;
                Thread.Title = reader["Title"].ToString();
                Thread.Id = (Guid) reader["Id"];
                Thread.Description = reader["Description"].ToString();
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
            //sql = "select *from Section order by DisplayOrder";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumThread Thread = new ForumThread();
                //item.Id = Convert.ToInt32(reader["Id"]);
                //item.Name = reader["Name"].ToString();
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
