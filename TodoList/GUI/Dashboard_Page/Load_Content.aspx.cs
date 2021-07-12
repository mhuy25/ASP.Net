using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Diagnostics;
using System.Web.Script.Serialization;

using TodoList.Models.BLL;
using TodoList.Models.DTO;

namespace TodoList.GUI.Dashboard_Page
{
    public partial class Load_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static string load_table_info(string value)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            string mystring = json.Deserialize<string>(value);
            List<Employee> list_employee = EmployeeBLL.getEmployeeJob2(Int32.Parse(mystring));
            string str = "<table class='table table-bordered table-hover pre-scrollable' id='table_info_employee'>" +
                                    "<thead>" +
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
            for (int i = 1; i <= list_employee.Count; i++)
            {
                str = str + "<tr id='employee_" + i + "' data-id='" + i + "' class='hidden'>";
                str = str + "<td data-name='id' class='text-center nv_id'>" + list_employee[i - 1].get_EmployeeID + "</td>";
                str = str + "<td data-name='name' class='text-center nv_name'>" + list_employee[i - 1].get_EmployeeName + "</td>";
                str = str + "<td data-name='name' class='text-center nv_email'>" + list_employee[i - 1].get_EmployeeEmail + "</td>";
                if (list_employee[i - 1].get_RoleID == 2)
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
        public static string load_table_employee()
        {
            Debug.WriteLine("Worked ! (load_table_employee)");
            List<Employee> list_employee = EmployeeBLL.getAll();
            int count = list_employee.Count;
            string str = "<div class='container'>" +
                                "<div class='row clearfix'>" +
                                    "<div class='col-md-12 table-responsive'>" +
                                        "<table class='table table-bordered table-hover pre-scrollable' id='employee_management_table'" +
                                            "<thead>" +
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
                                                    "Password" +
                                                "</th>" +
                                                "<th class='text-center'>" +
                                                    "Quyền" +
                                                "</th>" +
                                            "</thead>" +
                /* Chèn dữ liệu ở dưới*/
                                            "<tbody>";



            for (int i = 0; i < count; i++)
            {
                str = str + "<tr id='job_" + i + "' data-id='" + i + "' class='hidden'>";
                str = str + "<td data-name='id' class='text-center nv_id'>" + list_employee[i].get_EmployeeID + "</td>";
                str = str + "<td data-name='title' class='text-center nv_name'>" + list_employee[i].get_EmployeeName + "</td>";
                str = str + "<td data-name='startDate' class='text-center nv_email'>" + list_employee[i].get_EmployeeEmail + "</td>";
                str = str + "<td data-name='endDate' class='text-center nv_password'>" + list_employee[i].get_EmployeePassword + "</td>";
                if (list_employee[i].get_RoleID == 1)
                {
                    str = str + "<td data-name='state' class='text-center nv_role'>Manager</td>";
                }
                else
                {
                    str = str + "<td data-name='state' class='text-center nv_role'>Employee</td>";
                }
                str = str + "</tr>";
            }
            /* Chèn dữ liệu ở trên */
            str = str + "</tbody>" +
                                      "</table>" +
                                  "</div>" +

                              "</div>" +
                              "<a id='add_row' class='btn btn-primary float-right' data-toggle='modal' data-target='#modal_insert_employee'>Thêm nhân viên</a>" +
                          "</div>" +
                          "</div>";
            return str;
        }
        
        [WebMethod()]
        public static void Insert_Employee(string value)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            string mystring = json.Deserialize<string>(value);

            string[] array = value.Split('|');
            List<Employee> list_employee = EmployeeBLL.getAll();
            int count = list_employee.Count;
            for(int i = 1; i <= count; i++)
            {
                if(i != list_employee[i -1].get_EmployeeID)
                {
                    Employee e = new Employee();
                    e.get_EmployeeID = i;
                    e.get_EmployeeName = array[0];
                    e.get_EmployeeEmail = array[1];
                    e.get_EmployeePassword = array[2];
                    e.get_RoleID = Int32.Parse(array[3].Remove(array[3].Length - 1));
                    Debug.WriteLine(EmployeeBLL.Insert(e));
                }
                else if(i == count)
                {
                    Employee e = new Employee();
                    e.get_EmployeeID = i + 1;
                    e.get_EmployeeName = array[0];
                    e.get_EmployeeEmail = array[1];
                    e.get_EmployeePassword = array[2];
                    Debug.WriteLine(array[3]);
                    e.get_RoleID = Int32.Parse(array[3].Remove(array[3].Length - 1));
                    Debug.WriteLine(EmployeeBLL.Insert(e));
                }
            }
        }
    }
}