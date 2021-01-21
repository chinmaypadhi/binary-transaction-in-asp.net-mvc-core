using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using binary_transaction_in_asp.net_mvc_core.Models;
namespace binary_transaction_in_asp.net_mvc_core.Controllers
{
    public class myController : Controller
    {
        myallFunction allfn = new myallFunction();
        [HttpGet]
        public IActionResult Index()
        {
            return View(allfn.disp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(College cg)
        {
            if(ModelState.IsValid)
            {
                allfn.create(cg);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(allfn.search(id));
        }

        [ActionName("Delete")]
        public IActionResult del (int id)
        {
            if (ModelState.IsValid)
            {
                allfn.delete(id);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            
            return View(allfn.search(id));
        }
        [HttpGet]
        public IActionResult  Edit(int id)
        {
            return View(allfn.search(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, College entity)
        {
            if (ModelState.IsValid == true)
            {
               allfn.update(id,entity);
                return RedirectToAction("index");
            }
            return View(allfn.search(id));
        }

    }
}
