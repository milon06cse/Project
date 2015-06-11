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
  public  class UserRepository:BaseRepository
  {
      public bool Add(ForumUser fuser)
      {
          try
          {
              OpenConnection();
              DbCommand Command = CreateSqlCommand("insert into ForumUser(id,name,type,birthday,cellno,nid,address,zipcode) values(@id,@name,@type,@birthday,@cellno,@nid,@address,@zipcode)");
              Command.Parameters.Add(CreateParameter("Id", fuser.Id));
              Command.Parameters.Add(CreateParameter("Name", fuser.Name));
              Command.Parameters.Add(CreateParameter("Name", fuser.Type));
              Command.Parameters.Add(CreateParameter("birthday", fuser.Birthday));
              Command.Parameters.Add(CreateParameter("cellno", fuser.Cellno));
              Command.Parameters.Add(CreateParameter("nid", fuser.Nid));
              Command.Parameters.Add(CreateParameter("address", fuser.Address));
              Command.Parameters.Add(CreateParameter("zipcode", fuser.ZipCode));
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
      public List<ForumUser> ShowAllUser()
      {
          List<ForumUser> users = new List<ForumUser>();
          string sql = string.Empty;
          sql = "select *from ForumUser order by nid";
          OpenConnection();
          SqlCommand command = new SqlCommand();
          command.CommandText = sql;
          command.Connection = (SqlConnection)ConnectionBuilder();
          command.CommandType = System.Data.CommandType.Text;
          SqlDataReader reader = command.ExecuteReader();
          while (reader.Read())
          {
              ForumUser user = new ForumUser();
              //item.Id = Convert.ToInt32(reader["Id"]);
              user.Name = reader["Name"].ToString();
              //item.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
              users.Add(user);
          }
          reader.Close();
          reader.Dispose();
          reader = null;
          CloseConnection();
          return users;
      }
      public ForumUser UserByUserId(Guid ParentId)
      {
          ForumUser user = new ForumUser();
          string sql = string.Empty;
          sql = "select *from ForumUser where Id=@SectionId";
          OpenConnection();
          SqlCommand command = new SqlCommand();
          command.Parameters.Add(CreateParameter("SectionId", ParentId));
          command.CommandText = sql;
          command.Connection = (SqlConnection)ConnectionBuilder();
          command.CommandType = System.Data.CommandType.Text;
          SqlDataReader reader = command.ExecuteReader();
          if (reader.Read())
          {
              user.Name = reader["name"].ToString();
              user.Id = (Guid)reader["Id"];
              user.Cellno = reader["Cellno"].ToString();
              
          }
          reader.Close();
          reader.Dispose();
          reader = null;
          CloseConnection();

          return user;
      }
    }
}
