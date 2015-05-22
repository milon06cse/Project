using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess
{
    abstract public class BaseRepository
    {
        protected DbConnection Connection { get; set; }
        protected virtual bool OpenConnection()
        {
            if (Connection == null)
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Forum"].ConnectionString);
                //Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDbConnection"].ConnectionString);
            if (Connection != null && Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
                return true;
            }
            return false;
        }
        protected virtual DbConnection ConnectionBuilder()
        {
            if (Connection == null)
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDbConnection"].ConnectionString);
            return Connection;
        }
        protected virtual bool CloseConnection()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                return true;
            }
            return false;
        }
        protected virtual DbCommand CreateSqlCommand(string CommandText)
        {
            return new SqlCommand(CommandText,(SqlConnection)Connection);
        }
        protected virtual DbParameter CreateParameter(string name,object value)
        {
            return new SqlParameter(name, value);
        }
        protected virtual object ExecuteScalar(String sql)
        {
            OpenConnection();
            object obj = null;
            DbDataReader dataReader = null;
            DbCommand command = (DbCommand)new SqlCommand();
            try
            {
                command.CommandText = sql;
                command.Connection = Connection;
                //connection.Open();
            dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    obj = (object)dataReader[0];
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
                dataReader.Close();
            }

            return obj;
        }
        public virtual int MaxColumnValue(string Column, String TableName)
        {
            string sql = string.Format("select isnull( Max({0})+1,'1') from {1}", Column, TableName);
            object obj = ExecuteScalar(sql);
            return  Convert.ToInt32(obj);
        }
    }
}
