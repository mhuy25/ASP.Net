using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models.DTO
{
    public class Role
    {
        private int role_id;
        private string role_name;

        public Role() { }

        public Role(int role_id, string role_name)
        {
            this.role_id = role_id;
            this.role_name = role_name;
        }

        public int get_RoleID { get; set; }
        public string get_RoleName { get; set; }
    }
}