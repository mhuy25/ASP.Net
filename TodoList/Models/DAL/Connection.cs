using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TodoList.Models.DAL
{
    public static class Connection
    {
        private static SqlConnection getConnection()
        {
            return new SqlConnection("Server=localhost; Database=TodoList; Integrated Security=SSPI;");
        }

        public static int ExecuteCommand(String sql, params SqlParameter[] parameterList)
        {
            int result = 0;
            using (SqlConnection sqlconn = getConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddRange(parameterList);
                sqlconn.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static SqlDataReader ExecuteReader(String query, params SqlParameter[] parameterList)
        {
            try
            {
                SqlConnection sqlConn = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddRange(parameterList);
                sqlConn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }catch(Exception ex){
                throw ex;
            }
        }
    }
}