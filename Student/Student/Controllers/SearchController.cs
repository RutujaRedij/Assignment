using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.BizRepository;
using Student.Models;

namespace Student.Controllers
{
    public class SearchController : Controller
    {

        IBizRepository<StudentInfo, int> catRepository;
        IBizRepository<Course, int> corRepository;
        RHealDbContext ctx;
        public SearchController()
        {
            catRepository = new StudentBizRepository();
            corRepository = new CourseBizRepository();
            ctx = new RHealDbContext();
        }
        // GET: Search
        [Authorize(Roles = "Student")]
        public ActionResult Index(string Searchby, string search)
        {
            if (Searchby == "CourseName")
            {
                var model = ctx.Courses.Where(x => x.CourseName.StartsWith(search) || search == null).ToList();
                return View(model);
            }
            else
            {
                var model = ctx.Courses.Where(x => x.NumderofModules.ToString() == search || search == null).ToList();
                return View(model);
            }
        }
    }
}