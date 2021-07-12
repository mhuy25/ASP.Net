using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DAL;
using TodoList.Models.DTO;

namespace TodoList.Models.BLL
{
    public class JobBLL
    {
        private static JobDAL jd = new JobDAL();
        public static List<Job> getAll()
        {
            return jd.getAll();
        }

        public List<Job> getByJobStatus(int jobStatus)
        {
            return jd.getByJobStatus(jobStatus);
        }

        public List<Job> getByJobRange(int jobRange)
        {
            return jd.getByJobRange(jobRange);
        }

        public static List<Job> getEmployeeJob(int employee_id)
        {
            return jd.getEmployeeJob(employee_id);
        }

        public static int Insert(Job j)
        {
            return jd.Insert(j);
        }

        public static int Update(Job j)
        {
            return jd.Update(j);
        }

        public static int Update_Status(int i)
        {
            return jd.Update_Status(i);
        }

        public static int Delete(int id)
        {
            return jd.Delete(id);

        }
    }
}