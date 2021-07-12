using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models.DTO
{
    public class JobEmployee
    {
        private int employoee_id;
        private int job_id;


        public JobEmployee() { }

        public JobEmployee(int employee_id, int job_id)
        {
            this.employoee_id = employee_id;
            this.job_id = job_id;
        }

        public int get_EmployeeID { get; set; }
        public int get_JobID { get; set; }
    }
}