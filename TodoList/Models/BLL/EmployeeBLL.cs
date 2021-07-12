using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DAL;
using TodoList.Models.DTO;

namespace TodoList.Models.BLL
{
    public class EmployeeBLL
    {
        private static EmployeeDAL ed = new EmployeeDAL();
        public static List<Employee> getAll()
        {
            return ed.getAll();
        }

        public static Employee getByEmployeeId(int id)
        {
            return ed.getByEmployeeId(id);
        }

        public static Employee getByEmployeeName(string name)
        {
            return ed.getByEmployeeName(name);
        }

        public static List<Employee> getEmployeeJob(int job_id)
        {
            return ed.getEmployeeJob(job_id);
        }

        public static List<Employee> getEmployeeJob2(int job_id)
        {
            return ed.getEmployeeJob2(job_id);
        }

        public static int Insert(Employee e)
        {
            return ed.Insert(e);
        }

        public static int Update(Employee e)
        {
            return ed.Update(e);
        }

        public static int Delete(int id)
        {
            return ed.Delete(id);

        }
    }
}