using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models.DTO
{
    public class Employee
    {
        private int employee_id;
        private string employee_name;
        private string employee_email;
        private string employee_password;
        private int role_id;


        public Employee() { }

        public Employee(int employee_id, string employee_name, string employee_email, string employee_password, int role_id) {
            this.employee_id = employee_id;
            this.employee_name = employee_name;
            this.employee_email = employee_name;
            this.employee_password = employee_password;
            this.role_id = role_id;
        }

        public int get_EmployeeID { get; set; }
        public string get_EmployeeName { get; set; }
        public string get_EmployeeEmail { get; set; }
        public string get_EmployeePassword { get; set; }
        public int get_RoleID { get; set; }
    }
}