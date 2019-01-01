using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UowAndRepository.Models;
using UowAndRepository.UnitOfWork;

namespace UowAndRepository.Controllers
{
    public class TestController : Controller
    {
        private UOW unitOfWork=new UOW();
        // GET: Test
        public ActionResult Index()
        {
            var list = unitOfWork.ProductRepository.GetAllProduct();
            return View(list);
        }

        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            unitOfWork.ProductRepository.Delete(Id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Form(Product model)
        {
            unitOfWork.ProductRepository.Insert(model);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(Product model)
        {
            unitOfWork.ProductRepository.Update(model);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var model = unitOfWork.ProductRepository.GetProductById(Id);
            return View("Form",model);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}