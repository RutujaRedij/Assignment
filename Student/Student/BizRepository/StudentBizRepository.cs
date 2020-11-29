using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.Models;

namespace Student.BizRepository
{
    public class StudentBizRepository : IBizRepository<StudentInfo, int>
    {
        RHealDbContext ctx;

        public StudentBizRepository()
        {
            ctx = new RHealDbContext();
        }

        public StudentInfo Create(StudentInfo entity)
        {
            entity = ctx.Students.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Students.Find(id);
            if (res == null) return false;
            ctx.Students.Remove(res);
            ctx.SaveChanges();
            return true;

        }
        public List<StudentInfo> GetData()
        {
            var res = ctx.Students.ToList();
            return res;
        }

        public StudentInfo GetData(int id)
        {
            var res = ctx.Students.Find(id);
            return res;
        }

        public StudentInfo Update(int id, StudentInfo entity)
        {
            var res = ctx.Students.Find(id);
            if (res != null)
            {
                res.StudentId = entity.StudentId;
                res.StudentName = entity.StudentName;
                res.Email = entity.Email;
                res.Address = entity.Address;
                res.City = entity.City;
                res.AreaofInterest = entity.AreaofInterest;
                res.DOB = entity.DOB;
                res.CourseCompleted = entity.CourseCompleted;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }
}