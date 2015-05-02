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
                DbCommand Command = CreateSqlCommand("insert into Thread(Id,Title,SectionId,Description,CreationDate) values(@Id,@Title,@SectionId,@Description,@CreationDate)");
                Command.Parameters.Add(CreateParameter("SectionId", Thread.ParentId));
                Command.Parameters.Add(CreateParameter("Title", Thread.Title));
                Command.Parameters.Add(CreateParameter("Id", Thread.Id));
                Command.Parameters.Add(CreateParameter("Description", Thread.PostText));
                Command.Parameters.Add(CreateParameter("CreationDate", DateTime.Now));
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
        public List<ForumThread> ShowBySectionId(Guid ParentId)
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
                Thread.PostText = reader["Description"].ToString();
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
