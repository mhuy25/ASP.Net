using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.Models.DTO;

namespace TodoList.Models.DAL
{
    public class CommentDAL
    {
        public List<Comment> getAll()
        {
            List<Comment> list = new List<Comment>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Comment"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Comment()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_Comment = dr["comment"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Comment> getByJobId(int jobId)
        {
            List<Comment> list = new List<Comment>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Comment WHERE job_id=@job_id", new SqlParameter("@job_id", jobId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Comment()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_Comment = dr["comment"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public int Insert(Comment c)
        {
            string query = "INSERT INTO Comment(job_id, employee_id, comment) VALUES (@job_id, @employee_id, @comment";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", c.get_JobID),
                new SqlParameter("@employee_id", c.get_EmployeeID),
                new SqlParameter("@comment", c.get_Comment)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Update(Comment c)
        {
            string query = "UPDATE Comment SET comment=@comment WHERE job_id=@job_id AND employee_id=@employee_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", c.get_JobID),
                new SqlParameter("@employee_id", c.get_EmployeeID),
                new SqlParameter("@comment", c.get_Comment)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Delete(int jobId, int employeeId)
        {
            string query = "DELETE FROM Comment WHERE job_id=@job_id AND employee_id=@employee_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", jobId),
                new SqlParameter("@employee_id", employeeId)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }
    }
}