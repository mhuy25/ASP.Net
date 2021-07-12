using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DAL;
using TodoList.Models.DTO;

namespace TodoList.Models.BLL
{
    public class JobEmployeeBLL
    {
        private static JobEmployeeDAL jed = new JobEmployeeDAL();
        public static List<JobEmployee> getAll()
        {
            return jed.getAll();
        }

        public List<JobEmployee> getByEmployeeId(int employeeId)
        {
            return jed.getByEmployeeId(employeeId);
        }

        public List<JobEmployee> getByJobId(int jobId)
        {
            return jed.getByJobId(jobId);
        }

        

        public static int Insert(int c, int d)
        {
            return jed.Insert(c, d);
        }

        public int Update(JobEmployee c)
        {
            return jed.Update(c);
        }

        public int Delete(int jobId, int employeeId)
        {
            return jed.Delete(jobId, employeeId);
        }
    }
}