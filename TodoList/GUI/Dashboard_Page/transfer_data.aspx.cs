using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using TodoList.Models.DTO;
using TodoList.Models.BLL;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace TodoList.GUI.Dashboard_Page
{
    public partial class transfer_data : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private static List<Job> getAllJob()
        {
            List<Job> job = new List<Job>();
            return job = JobBLL.getAll();
        }

        [WebMethod]
        public static void Insert(string value)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            List<string[]> mystring = json.Deserialize<List<string[]>>(value);
            List<string> values = new List<string>();
            foreach(string[]  strings in mystring)
            {
                foreach(string s in strings)
                {
                    values.Add(s);
                }
            }
            
            List<Job> job = getAllJob();
            int count = job.Count;
            int lastValue = values.Count - 1;
            int flag = 0;
            string text = values[lastValue];
            Debug.WriteLine(count);
            for (int i = 1; i <= count; i++)
            {
                Debug.WriteLine(job[i - 1].get_JobID);
                if (i != job[i - 1].get_JobID)
                {
                    Debug.WriteLine("Violation 1");
                    string[] array = text.Split('|');
                    if (array[3].Equals("Public"))
                    {
                        flag = i;
                        Job a;
                        a = new Job(i, array[0].ToString(),array[1], array[2], 0, 1);
                        Debug.WriteLine("Insert: " + JobBLL.Insert(a));
                    }
                    else
                    {
                        flag = i;
                        Job a;
                        a = new Job(i, array[0].ToString(), array[1], array[2], 0, 0);
                        Debug.WriteLine("Insert: " + JobBLL.Insert(a));
                    }
                    //JobEmployeeBLL.Insert(i);
                    break;
                }
                if(i == count)
                {
                    Debug.WriteLine("Violation 2");
                    string[] array = text.Split('|');
                    if (array[3].Equals("Public"))
                    {
                        flag = i + 1;
                        Job a;
                        a = new Job(i + 1, array[0].ToString(), array[1], array[2], 0, 1);
                        Debug.WriteLine("Insert: " + JobBLL.Insert(a));
                    }
                    else
                    {
                        flag = i + 1;
                        Job a;
                        a = new Job(i + 1, array[0].ToString(), array[1], array[2], 0, 0);
                        Debug.WriteLine("Insert: " + JobBLL.Insert(a));
                    }
                    //JobEmployeeBLL.Insert(i);
                    break;
                }
            }
            for (int i = 0; i < lastValue; i++)
            {
                JobEmployeeBLL.Insert(flag, Int32.Parse(values[i]));
            }
        }
    }
}