using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models.DAL;
using TodoList.Models.DTO;

namespace TodoList.Models.BLL
{
    public class CommentBLL
    {
        private static CommentDAL cd = new CommentDAL();
        public List<Comment> getAll()
        {  
            return cd.getAll();
        }

        public List<Comment> getByJobId(int jobId)
        {
            return cd.getByJobId(jobId);
        }

        public int Insert(Comment c)
        {
            return cd.Insert(c);
        }

        public int Update(Comment c)
        {
            return cd.Update(c);
        }

        public int Delete(int jobId, int employeeId)
        {
            return cd.Delete(jobId, employeeId);
        }
    }
}