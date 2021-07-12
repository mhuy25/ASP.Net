using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models.DTO
{
    public class Comment
    {
        private int employoee_id;
        private int job_id;
        private string comment;


        public Comment() { }

        public Comment(int employee_id, int job_id, string comment)
        {
            this.employoee_id= employee_id;
            this.job_id=job_id;
            this.comment=comment;
        }

        public int get_EmployeeID { get; set; }
        public int get_JobID { get; set; }
        public string get_Comment { get; set; }

    }
}