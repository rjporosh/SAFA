using SAFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAFA.Controllers
{
    public class tryController : Controller
    {
        SBMDBEntities _db = new SBMDBEntities();
        // GET: try
        public ActionResult Index()
        {
            return View();
        }

        // GET: try/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: try/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: try/Create
        [HttpPost]
        public ActionResult Create(BankBranch bankBranch)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    _db.BankBranches.Add(bankBranch);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bankBranch);
            }
            catch
            {
                return View();
            }
        }

        // GET: try/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: try/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: try/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: try/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
