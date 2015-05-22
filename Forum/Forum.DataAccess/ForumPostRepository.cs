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
   public class ForumPostRepository:BaseRepository
    {
        public bool Add(ForumPost Post)
        {
            try
            {
                OpenConnection();
                DbCommand Command = CreateSqlCommand("insert into Post(Id,PostText,ThreadId,CreationDate,UserId) values(@Id,@PostText,@ThreadId,@CreationDate,@UserId)");
                Command.Parameters.Add(CreateParameter("ThreadId", Post.ParentId));
                Command.Parameters.Add(CreateParameter("PostText", Post.PostText));
                Command.Parameters.Add(CreateParameter("Id", Post.Id));
                Command.Parameters.Add(CreateParameter("UserId", Post.UserId));
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
        public bool Edit(ForumPost Thread)
        {
            return false;
        }
        public bool Delete(ForumPost Thread)
        {
            return false;
        }
        public List<ForumPost> PostsByThreadId(Guid ParentId)
        {
            List<ForumPost> Posts = new List<ForumPost>();
            string sql = string.Empty;
            sql = "select *from Post where ThreadId=@ThreadId";
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Parameters.Add(CreateParameter("ThreadId", ParentId));
            command.CommandText = sql;
            command.Connection = (SqlConnection)ConnectionBuilder();
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumPost Post = new ForumPost();
                Post.ParentId = ParentId;
               // Post.Title = reader["Title"].ToString();
                Post.Id = (Guid)reader["Id"];
                Post.PostText = reader["PostText"].ToString();
                Posts.Add(Post);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();

            return Posts;
        }
        public List<ForumPost> ShowAll()
        {
            List<ForumPost> Posts = new List<ForumPost>();
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
                ForumPost Post = new ForumPost();
                //item.Id = Convert.ToInt32(reader["Id"]);
                //item.Name = reader["Name"].ToString();
                //item.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
                //Sections.Add(item);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            CloseConnection();
            return Posts;
        }
    }
}
