using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.Models.DTO;

namespace TodoList.Models.DAL
{
    public class RoleDAL
    {
        public List<Role> getAll()
        {
            List<Role> list = new List<Role>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Role"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Role()
                        {
                            get_RoleID = Int32.Parse(dr["role_id"].ToString()),
                            get_RoleName = dr["role_name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Role getByRoleId(int roleId)
        {
            List<Role> list = new List<Role>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Role WHERE role_id=@role_id", new SqlParameter("@role_id", roleId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return new Role()
                        {
                            get_RoleID = Int32.Parse(dr["role_id"].ToString()),
                            get_RoleName = dr["role_name"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int Insert(Role r)
        {
            string query = "INSERT INTO Role(role_id, role_name) VALUES (@role_id, @role_name";
            SqlParameter[] parameterList = {
                new SqlParameter("@role_id", r.get_RoleID),
                new SqlParameter("@role_name", r.get_RoleName)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Update(Role r)
        {
            string query = "UPDATE Role SET role_name=@role_name WHERE role_id=@role_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@role_id", r.get_RoleID),
                new SqlParameter("@role_name", r.get_RoleName)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Delete(int roleId)
        {
            string query = "DELETE FROM Role WHERE role_id=@role_id";
            return Connection.ExecuteCommand(query, new SqlParameter("@role_id", roleId));
        }

    }
}