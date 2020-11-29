using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.BizRepository;
using Student.Models;

namespace Student.Controllers
{
    public class TrainerController : Controller
    {
        IBizRepository<Trainer, int> traRepository;
        public TrainerController()
        {
            traRepository = new TrainerBizRepository();
        }
        // GET: Trainer
        [Authorize(Roles="Trainer")]
        public ActionResult Index()
        {
            var result = traRepository.GetData();
            return View(result);
        }
        public ActionResult Create()
        {
            var result = new Trainer();
            return View(result);
        }
        [HttpPost]
        public ActionResult Create(Trainer data)
        {

            if (ModelState.IsValid)
            {
                data = traRepository.Create(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var result = traRepository.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, Trainer data)
        {
            if (ModelState.IsValid)
            {
                traRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var result = traRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}