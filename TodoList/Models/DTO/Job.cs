using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace TodoList.Models.DTO
{
    public class Job
    {
        private int job_id;
        private string job_title;
        private string job_startDate;
        private string job_finishDate;
        private int job_status;
        private int job_range;


        public Job() { }

        public Job(int job_id, string title, string job_startDate, string job_finishDate, int job_status, int job_range) {
            this.job_id = job_id;
            job_title = title;
            this.job_startDate = job_startDate;
            this.job_finishDate = job_finishDate;
            this.job_status = job_status;
            this.job_range = job_range;
            Debug.WriteLine(title);
            Debug.WriteLine(job_startDate);
            Debug.WriteLine(job_finishDate);
        }
        public int get_ID()
        {
            return job_id;
        }

        public string get_Title()
        {
            return job_title;
        }

        public string get_JobStart()
        {
            return job_startDate;
        }

        public string get_JobEnd()
        {
            return job_finishDate;
        }

        public int get_Range()
        {
            return job_range;
        }

        public int get_Status()
        {
            return job_status;
        }

        public int get_JobID { get; set; }
        public string get_JobTitle { get; set; }
        public string get_JobStartDate { get; set; }
        public string get_JobFinishDate { get; set; }
        public int get_JobStatus { get; set; }
        public int get_JobRange { get; set; }
    }
}