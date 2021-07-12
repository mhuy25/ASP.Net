using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.Models.DTO;

namespace TodoList.Models.DAL
{
    public class JobEmployeeDAL
    {
        public List<JobEmployee> getAll()
        {
            List<JobEmployee> list = new List<JobEmployee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM JobEmployee"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new JobEmployee()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<JobEmployee> getByEmployeeId(int employeeId)
        {
            List<JobEmployee> list = new List<JobEmployee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM JobEmployee WHERE employee_id=@employee_id", new SqlParameter("@employee_id", employeeId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new JobEmployee()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<JobEmployee> getByJobId(int jobId)
        {
            List<JobEmployee> list = new List<JobEmployee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM JobEmployee WHERE job_id=@job_id", new SqlParameter("@job_id", jobId)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new JobEmployee()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public int Insert(int c, int d)
        {
            string query = "INSERT INTO JobEmployee(job_id, employee_id) VALUES (@c, @d)";
            SqlParameter[] parameterList = {
                new SqlParameter("@c", c),
                new SqlParameter("@d", d)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Update(JobEmployee c)
        {
            string query = "UPDATE JobEmployee SET employee_id=@employee_id WHERE job_id=@job_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", c.get_JobID),
                new SqlParameter("@employee_id", c.get_EmployeeID)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Delete(int jobId, int employeeId)
        {
            string query = "DELETE FROM JobEmployee WHERE job_id=@job_id AND employee_id=@employee_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", jobId),
                new SqlParameter("@employee_id", employeeId)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }
    }
}