using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DAL;
using TodoList.Models.DTO;

namespace TodoList.Models.BLL
{
    public class RoleBLL
    {
        private static RoleDAL rd = new RoleDAL();
        public static List<Role> getAll()
        {
            return rd.getAll();
        }

        public Role getByRoleId(int roleId)
        {
            return rd.getByRoleId(roleId);
        }

        public static int Insert(Role j)
        {
            return rd.Insert(j);
        }

        public static int Update(Role j)
        {
            return rd.Update(j);
        }

        public static int Delete(int id)
        {
            return rd.Delete(id);

        }
    }
}