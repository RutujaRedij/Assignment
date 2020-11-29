using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.BizRepository;
using Student.Models;

namespace Student.Controllers
{
    public class StudentInfoController : Controller
    {
        // GET: StudentInfo
        IBizRepository<StudentInfo, int> catRepository;
        IBizRepository<Course, int> croRepository;
        RHealDbContext context;
        public StudentInfoController()
        {
            context = new RHealDbContext();
            catRepository = new StudentBizRepository();
            croRepository = new CourseBizRepository();
        }
        [Authorize(Roles ="Student")]
        public ActionResult Index()
        {

            var result = catRepository.GetData();
            return View(result);
        }
        public ActionResult Create()
        {
            var result = new StudentInfo();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(StudentInfo data)
        {

            if (ModelState.IsValid)
            {
                data = catRepository.Create(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var result = catRepository.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, StudentInfo data)
        {
            if (ModelState.IsValid)
            {
                catRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var result = catRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult search(string searchName)
        {
            var result = from pr in catRepository.GetData() select pr;
            if(!String.IsNullOrEmpty(searchName))
            {
                result = result.Where(c => c.StudentName.Contains(searchName));
            }
            return View(result);
        }
        public ActionResult register()
        {
            ViewBag.StudentId=new SelectList(catRepository.GetData(),"StudentKeyId","StudentName");
            ViewBag.CourseKeyId = new SelectList(croRepository.GetData(),"CourseKeyId","CourseName");
            return View();
        }
        //[HttpPost]
        //public ActionResult register(int studentid,int courseid)
        //{
        //    var res =context.Studentcources();
        //    return View("Index");
        //}
    }


}