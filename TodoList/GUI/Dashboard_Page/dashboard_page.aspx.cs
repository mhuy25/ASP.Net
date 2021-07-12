using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Web.Services;


using TodoList.Models.BLL;
using TodoList.Models.DTO;

namespace TodoList.GUI.Dashboard_Page
{
    public partial class dashboard_page : System.Web.UI.Page
    {
        private string id;

        private static List<Job> getAllJob()
        {
            List<Job> job = new List<Job>();
            return job = JobBLL.getAll();
        }

        [WebMethod()]
        public static void Delete(string value)
        {
            Debug.WriteLine(JobBLL.Delete(Int32.Parse(value)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                name.InnerText = "Xin chào, " + Session["name"].ToString();
            }
            if (Session["role"] != null)
            {
                if (!Session["role"].ToString().Equals("2"))
                {
                    manage.Style.Add("display", "none");
                }
            }
            if (Session["id"] != null)
            {
                id = Session["id"].ToString();
                
            }
            job_observe.Click += new EventHandler(Loader);
        }

        private List<Job> getJobs()
        {
            List<Job> job_list = new List<Job>();
            if (Session["role"] != null)
            {
                if(Session["role"].ToString().Equals("2"))
                {
                    job_list = JobBLL.getAll();
                }
                else
                {
                    job_list = JobBLL.getEmployeeJob(Int32.Parse(id));
                }
            }
            else
            {
                job_list = JobBLL.getEmployeeJob(1);
            }
            return job_list;
        }

        private static void load(int id)
        {

        }

        [WebMethod()]
        public static string load_edit_table(string value)
        {
            Debug.WriteLine("Load table edit ... ");
            JavaScriptSerializer json = new JavaScriptSerializer();
            List<string[]> mystring = json.Deserialize<List<string[]>>(value);
            List<string> values = new List<string>();
            foreach (string[] strings in mystring)
            {
                foreach (string s in strings)
                {
                    values.Add(s);
                }
            }
            List<Employee> list = new List<Employee>();
            list = EmployeeBLL.getEmployeeJob(Int32.Parse(values[0]));
            int n = list.Count;
            string str = "<table class='table table-bordered table-hover pre-scrollable' id='table_edit_employee'>" +
                                    "<thead>" +
                                        "<th class='text-center'>" +

                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "ID" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Tên nhân viên" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Email" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Quyền" +
                                        "</th>" +
                                    "</thead>" +
                                    "<tbody>";
            for(int i = 1; i <= n; i++)
            {
                str = str + "<tr id='employee_" + i + "' data-id='" + i + "' class='hidden'>";
                str = str + "<td data-name='check'><input type='checkbox' /></td>";
                str = str + "<td data-name='id' class='text-center nv_id'>" + list[i - 1].get_EmployeeID + "</td>";
                str = str + "<td data-name='name' class='text-center nv_name'>" + list[i - 1].get_EmployeeName + "</td>";
                str = str + "<td data-name='name' class='text-center nv_email'>" + list[i - 1].get_EmployeeEmail + "</td>";
                if (list[i - 1].get_RoleID == 2)
                {
                    str = str + "<td data-name='name' class='text-center nv_role'>Manager</td>";
                }
                else
                {
                    str = str + "<td data-name='name' class='text-center nv_role'>Employee</td>";
                }
                str = str + "</tr>";
            }
            str = str + "</tbody>" +
                       "</table>";
            return str;
        }

        [WebMethod()]
        public static void Change_Finish(string value)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            string mystring = json.Deserialize<string>(value);
            Debug.WriteLine(JobBLL.Update_Status(Int32.Parse(mystring)));
        }
        
        [WebMethod()]
        public static void Update_Job(string value)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            List<string[]> mystring = json.Deserialize<List<string[]>>(value);
            List<string> values = new List<string>();
            foreach (string[] strings in mystring)
            {
                foreach (string s in strings)
                {
                    values.Add(s);
                }
            }
            int count = values.Count;
            int job_id = Int32.Parse(values[count - 1].Split('|')[0]);
            for (int i = 0; i < count - 1; i++)
            {
                JobEmployeeBLL.Insert(job_id, Int32.Parse(values[i]));
            }
            string[] array = values[count - 1].Split('|');
            Job j = new Job();
            j.get_JobID = Int32.Parse(array[0]);
            j.get_JobTitle = array[1];
            j.get_JobStartDate = array[2];
            j.get_JobFinishDate = array[3];
            if (array[4].Equals("Public"))
            {
                j.get_JobRange = 1;
            }
            else
            {
                j.get_JobRange = 0;
            }
            Debug.WriteLine(JobBLL.Update(j));
        }

        private static List<Employee> getAllEmployee()
        {
            List<Employee> list_employee = new List<Employee>();
            return list_employee = EmployeeBLL.getAll();
        }

        public void Loader(Object sender, EventArgs e)
        {
            Debug.WriteLine("Loader");
           List<Job> job_list = getJobs();
           int count = job_list.Count;
          
           string str =      "<div class='container'>" +
                                "<div class='row clearfix'>" +
                                    "<div class='col-md-12 table-responsive'>" +
                                        "<table class='table table-bordered table-hover pre-scrollable' id='tab_logic'" +
                                            "<thead>" +
                                                "<tr>" +
                                                    "<th class='text-center'>" +
                                                        "ID" +
                                                    "</th>" +
                                                    "<th class='text-center'>" +
                                                        "Tên công việc" +
                                                    "</th>" +
                                                    "<th class='text-center'>" +
                                                        "Ngày bắt đầu" +
                                                    "</th>" +
                                                    "<th class='text-center'>" +
                                                        "Ngày kết thúc" +
                                                    "</th>" +
                                                    "<th class='text-center'>" +
                                                        "Danh sách nhân viên" +
                                                    "</th>" +
                                                    "<th class='text-center'>" +
                                                        "Chế độ công việc" +
                                                    "</th>" +
                                                    "<th class='text-center'></th>" +
                                                    "<th class='text-center'></th>" +
                                                    "<th class='text-center'></th>" +
                                                "</tr>" +
                                            "</thead>" +
                            /* Chèn dữ liệu ở dưới*/
                                            "<tbody>";
                                                
                            
           
               for (int i = 0; i < count; i++)
               {
                   str = str + "<tr id='job_" + i + "' data-id='" + i + "' class='hidden'>";
                   str = str + "<td data-name='id' class='text-center job_id'>" + job_list[i].get_JobID + "</td>";
                   str = str + "<td data-name='title' class='text-center job_title'>" + job_list[i].get_JobTitle + "</td>";
                   str = str + "<td data-name='startDate' class='text-center job_startDate'>" + job_list[i].get_JobStartDate + "</td>";
                   str = str + "<td data-name='endDate' class='text-center job_finishDate'>" + job_list[i].get_JobFinishDate + "</td>";
                   if (job_list[i].get_JobStatus == 1)
                   {
                       str = str + "<td data-name='state' class='text-center job_Status'>Đã hoàn thành</td>";
                   }
                   else
                   {
                       str = str + "<td data-name='state' class='text-center job_Status'>Chưa hoàn thành</td>";
                   }

                   if (job_list[i].get_JobRange == 1)
                   {
                       str = str + "<td data-name='regime' id='edit_job_range' class='text-center job_Range'>Public</td>";
                   }
                   else
                   {
                       str = str + "<td data-name='regime' id='edit_job_range' class='text-center job_Range'>Private</td>";
                   }
                   str = str + "<td data-name='check'><button name='check_" + i +"' class='btn btn-success finish_btn'><i class='fa fa-check'></i></button></td>";
                   str = str + "<td data-name='info'><button data-toggle='modal' data-target='#modal_info' name='info_" + i + "' class='btn btn-info info_btn'>Info</button></td>";
                   str = str + "<td data-name='edit'><button data-toggle='modal' data-target='#modal_edit' name='edit_" + i + "' class='btn btn-primary edit_btn'>Edit</button></td>";
                   str = str + "<td data-name='del'><button name='del_" + i + "' class='btn btn-danger glyphicon glyphicon-remove row-remove del'><span aria-hidden='true'>X</span></button></td>";
                   str = str + "</tr>";
               }
                            /* Chèn dữ liệu ở trên */
                str = str +                   "</tbody>" +
                                          "</table>" +
                                      "</div>" +
                                      
                                  "</div>" +
                                  "<a id='add_row' class='btn btn-primary float-right' data-toggle='modal' data-target='#myModal'>Thêm công việc</a>" +
                              "</div>" +
                              "</div>";
            
            content.InnerHtml = str;
        }

        protected void log_out_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["name"] = null;
            Session["role"] = null;
            Response.Redirect("../Login/Login.aspx");
        }

        protected void table_employee_Load(object sender, EventArgs e)
        {
            List<Employee> list_employee = getAllEmployee();
            List<string> array = new List<string>();
            string str_body = "<table class='table table-bordered table-hover table-sortable pre-scrollable' id='table_employee'>" +
                                    "<thead>" +
                                        "<th class='text-center'>" +

                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "ID" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Tên nhân viên" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Email" +
                                        "</th>" +
                                        "<th class='text-center'>" +
                                            "Quyền" +
                                        "</th>" +
                                    "</thead>" +
                                    "<tbody>";

            for (int i = 0; i < list_employee.Count; i++)
            {
                str_body = str_body + "<tr id='employee_" + i + "' data-id='" + i + "' class='hidden'>";
                str_body = str_body + "<td data-name='check'><input type='checkbox' /></td>";
                str_body = str_body + "<td data-name='id' class='text-center nv_id'>" + list_employee[i].get_EmployeeID + "</td>";
                str_body = str_body + "<td data-name='name' class='text-center nv_name'>" + list_employee[i].get_EmployeeName + "</td>";
                str_body = str_body + "<td data-name='name' class='text-center nv_email'>" + list_employee[i].get_EmployeeEmail + "</td>";
                if (list_employee[i].get_RoleID == 2)
                {
                    str_body = str_body + "<td data-name='name' class='text-center nv_role'>Manager</td>";
                }
                else
                {
                    str_body = str_body + "<td data-name='name' class='text-center nv_role'>Employee</td>";
                }
                str_body = str_body + "</tr>";
            }
            str_body = str_body + "</tbody></table>";
            load_table.InnerHtml = str_body;
        }



        
    }
}