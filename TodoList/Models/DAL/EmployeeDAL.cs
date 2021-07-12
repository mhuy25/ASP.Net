using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DTO;
using System.Data.SqlClient;
using System.Data;

namespace TodoList.Models.DAL
{
    public class EmployeeDAL
    {
        public List<Employee> getAll(){
            List<Employee> list = new List<Employee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Employee"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Employee()
                        {
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_EmployeeName = dr["employee_name"].ToString(),
                            get_EmployeeEmail = dr["employee_email"].ToString(),
                            get_EmployeePassword = dr["employee_password"].ToString(),
                            get_RoleID = Int32.Parse(dr["role_id"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public Employee getByEmployeeId(int id)
        {
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Employee WHERE employee_id=@id", new SqlParameter("@id", id)))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        return new Employee()
                        {
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_EmployeeName = dr["employee_name"].ToString(),
                            get_EmployeeEmail = dr["employee_email"].ToString(),
                            get_EmployeePassword = dr["employee_password"].ToString(),
                            get_RoleID = Int32.Parse(dr["role_id"].ToString())
                        };
                    }
                }
            }
            return null;
        }

        public Employee getByEmployeeName(string employeeName)
        {
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * FROM Employee WHERE employee_name=@employee_name", new SqlParameter("@employee_name", employeeName)))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        return new Employee()
                        {
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_EmployeeName = dr["employee_name"].ToString(),
                            get_EmployeeEmail = dr["employee_email"].ToString(),
                            get_EmployeePassword = dr["employee_password"].ToString(),
                            get_RoleID = Int32.Parse(dr["role_id"].ToString())
                        };
                    }
                }
            }
            return null;
        }

        public List<Employee> getEmployeeJob2(int job_id)
        {
            List<Employee> list = new List<Employee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * " +
                                                               "FROM Employee " +
                                                               "WHERE employee_id IN (SELECT je.employee_id " +
                                                                                     "FROM JobEmployee je " +
                                                                                     "WHERE job_id=@job_id) ",
                new SqlParameter("@job_id", job_id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Employee()
                        {
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_EmployeeName = dr["employee_name"].ToString(),
                            get_EmployeeEmail = dr["employee_email"].ToString(),
                            get_EmployeePassword = dr["employee_password"].ToString(),
                            get_RoleID = Int32.Parse(dr["role_id"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public List<Employee> getEmployeeJob(int job_id) 
        {
            List<Employee> list = new List<Employee>();
            using (SqlDataReader dr = Connection.ExecuteReader("SELECT * " +
                                                               "FROM Employee " +
                                                               "WHERE employee_id NOT IN (SELECT je.employee_id " +
                                                                                         "FROM JobEmployee je " +
                                                                                         "WHERE job_id=@job_id) ",
                new SqlParameter("@job_id", job_id)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Employee()
                        {
                            get_EmployeeID = Int32.Parse(dr["employee_id"].ToString()),
                            get_EmployeeName = dr["employee_name"].ToString(),
                            get_EmployeeEmail = dr["employee_email"].ToString(),
                            get_EmployeePassword = dr["employee_password"].ToString(),
                            get_RoleID = Int32.Parse(dr["role_id"].ToString())
                        });
                    }
                }
            }
            return list;   
        }

        public int Insert(Employee e)
        {
            string query = "INSERT INTO Employee(employee_id, employee_name, employee_email, employee_password, role_id) VALUES (@employee_id, @employee_name, @employee_email, @employee_password, @employee_role)";
            SqlParameter[] parameterList = {
                new SqlParameter("@employee_id", e.get_EmployeeID),
                new SqlParameter("@employee_name", e.get_EmployeeName),
                new SqlParameter("@employee_email", e.get_EmployeeEmail),
                new SqlParameter("@employee_password", e.get_EmployeePassword),
                new SqlParameter("@employee_role", e.get_RoleID)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }


        public int Update(Employee e)
        {
            string query = "UPDATE Employee SET employee_name=@employee_name, employee_email=@employee_email, employee_password=@employee_password, employee_role=@employee_role WHERE employee_id=@employee_id";
            SqlParameter[] parameterList = {
                new SqlParameter("@employee_id", e.get_EmployeeID),
                new SqlParameter("@employee_name", e.get_EmployeeName),
                new SqlParameter("@employee_email", e.get_EmployeeEmail),
                new SqlParameter("@employee_password", e.get_EmployeePassword),
                new SqlParameter("@employee_role", e.get_RoleID)
            };
            return Connection.ExecuteCommand(query, parameterList);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Employee WHERE employee_id=@employee_id";
            return Connection.ExecuteCommand(query, new SqlParameter("@employee_id", id));
        }
    }
}