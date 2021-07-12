using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using TodoList.Models.BLL;
using TodoList.Models.DTO;
using System.Text.RegularExpressions;


namespace TodoList.GUI
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           Error.Text = "Mã nhân viên hoặc mật khẩu chưa hợp lệ";
           username.Focus();

           string processScript = "this.value='Đang kiểm tra...'; this.disabled=true;";
           login.Attributes.Add("OnClick", processScript + ClientScript.GetPostBackEventReference(login, "").ToString()); 
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(username.Text, @"^\d+$"); //Regex kiểm tra mã nhân viên chỉ toàn là số, VD: N003 (sai), 003 hoặc 3 là đúng
            if (match.Success)
            {
                Employee em = EmployeeBLL.getByEmployeeId(Int32.Parse(username.Text));
                if (em != null)
                {                    
                    if (password.Text.Equals(em.get_EmployeePassword))
                    {
                        Session["id"] = em.get_EmployeeID;
                        Session["name"] = em.get_EmployeeName.Trim();
                        Session["role"] = em.get_RoleID;
                        Response.Redirect("../Dashboard_Page/dashboard_page.aspx");
                    }  
                    else
                    {
                        Error.Visible = true;
                        Error.Text = "Mật khẩu không chính xác";
                    }
                }
                else
                {
                    Error.Visible = true;
                    Error.Text = "Không tồn tại mã nhân viên này";
                }
                    
            }
            else
                Error.Visible = true;
        }
    }
}