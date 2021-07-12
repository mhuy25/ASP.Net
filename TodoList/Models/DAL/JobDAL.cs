using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.Models.DTO;
using System.Diagnostics;

namespace TodoList.Models.DAL
{
    public class JobDAL
    {
        public List<Job> getAll()
        {
            List<Job> list = new List<Job>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Job"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Job()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_JobTitle = dr["job_title"].ToString(),
                            get_JobStartDate = dr["job_start"].ToString(),
                            get_JobFinishDate = dr["job_end"].ToString(),
                            get_JobStatus = Int32.Parse(dr["job_status"].ToString()),
                            get_JobRange = Int32.Parse(dr["job_range"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<Job> getEmployeeJob(int employee_id)
        {
            List<Job> list = new List<Job>();
            string str = "SELECT * " +
                          "FROM Job " +
                          "WHERE job_range = '1' " +
                           "OR job_id IN (SELECT job_id " +
                                           "FROM Job " +
                                         "WHERE job_id IN (SELECT job_id " +
                                                           "FROM JobEmployee " +
                                                           "WHERE employee_id='" + employee_id + "'))";
            Console.WriteLine(str);
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * " +
                                                               "FROM Job " +
                                                               "WHERE job_range = '1' " +
                                                                     "OR job_id IN (SELECT job_id " +
                                                                                   "FROM Job " +
                                                                                   "WHERE job_id IN (SELECT job_id " +
                                                                                                    "FROM JobEmployee " +
                                                                                                    "WHERE employee_id=@employee_id)) ",
                                                                new SqlParameter("@employee_id", employee_id)
                                                              )
                  )
            
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Job()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_JobTitle = dr["job_title"].ToString(),
                            get_JobStartDate = dr["job_start"].ToString(),
                            get_JobFinishDate = dr["job_end"].ToString(),
                            get_JobStatus = Int32.Parse(dr["job_status"].ToString()),
                            get_JobRange = Int32.Parse(dr["job_range"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<Job> getByJobStatus(int jobStatus)
        {
            List<Job> list = new List<Job>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Job WHERE job_status=@job_status", new SqlParameter("@job_status", jobStatus)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Job()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_JobTitle = dr["job_title"].ToString(),
                            get_JobStartDate = dr["job_start"].ToString(),
                            get_JobFinishDate = dr["job_end"].ToString(),
                            get_JobStatus = Int32.Parse(dr["job_status"].ToString()),
                            get_JobRange = Int32.Parse(dr["job_range"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<Job> getByJobRange(int jobRange)
        {
            List<Job> list = new List<Job>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Job WHERE job_range=@job_range", new SqlParameter("@job_range", jobRange)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Job()
                        {
                            get_JobID = Int32.Parse(dr["job_id"].ToString()),
                            get_JobTitle = dr["job_title"].ToString(),
                            get_JobStartDate = dr["job_start"].ToString(),
                            get_JobFinishDate = dr["job_end"].ToString(),
                            get_JobStatus = Int32.Parse(dr["job_status"].ToString()),
                            get_JobRange = Int32.Parse(dr["job_range"].ToString())
                        });
                    }
                }
            }
            return list;
        }
    
        public int Insert(Job j)
        {
            Debug.WriteLine(j.get_ID());
            string query = "INSERT INTO Job(job_id, job_title, job_start, job_end, job_status, job_range) VALUES (@job_id, @job_title, @job_start, @job_end, @job_status, @job_range)";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", j.get_ID()),
                new SqlParameter("@job_title", j.get_Title()),
                new SqlParameter("@job_start", j.get_JobStart()),
                new SqlParameter("@job_end", j.get_JobEnd()),
                new SqlParameter("@job_status", j.get_Status()),
                new SqlParameter("@job_range", j.get_Range()),
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Update(Job j)
        {
            string query = "UPDATE Job SET job_title=@job_title, job_start=@job_start, job_end=@job_end, job_range=@job_range WHERE job_id=@job_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", j.get_JobID),
                new SqlParameter("@job_title", j.get_JobTitle),
                new SqlParameter("@job_start", j.get_JobStartDate),
                new SqlParameter("@job_end", j.get_JobFinishDate),
                new SqlParameter("@job_range", j.get_JobRange),
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Update_Status(int i)
        {
            string query = "UPDATE Job SET job_status=1 WHERE job_id=@job_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@job_id", i),
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Job WHERE job_id=@job_id";
            return Connection.ExecuteCommand(query, new SqlParameter("@job_id", id));
        }
    }
}