using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.BizRepository;
using Student.Models;

namespace Student.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        IBizRepository<Course, int> corRepository;
        IBizRepository<Trainer, int> traRepository;
        public CourseController()
            {
            corRepository = new CourseBizRepository();
            traRepository = new TrainerBizRepository();
            }
        public ActionResult Index()
        {
            var result = corRepository.GetData();
            ViewBag.TrainerRowId = new SelectList(traRepository.GetData(), "TrainerRowId", "TrainerName");
            return View(result);
        }
        [Authorize(Roles = "Trainer")]
        public ActionResult Create()
        {
            var result = new Course();
            return View(result);
        }
        [HttpPost]
        public ActionResult Create(Course data)
        {
            if(ModelState.IsValid)
            {
                data = corRepository.Create(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var result = corRepository.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, Course data)
        {
            if (ModelState.IsValid)
            {
                corRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var result = corRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}