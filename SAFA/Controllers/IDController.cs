using SAFA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAFA.Controllers
{
    public class IDController : Controller
    {
        SBMDBEntities db;
        public IDController() {
            db = new SBMDBEntities();
        }
        // GET: ID
        public ActionResult id_proof()
        {
            return View();
        }
        public ActionResult add_id_proof()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_id_proof(IdProofType idProofType)
        {
            idProofType.CreatedDate = DateTime.Now;
            idProofType.UpdatedDate = DateTime.Now;
            idProofType.IsActive = true;
            db.IdProofTypes.Add(idProofType);
            db.SaveChanges();
            return View("id_proof");
        }
        public ActionResult edit_id_proof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult edit_id_proof(IdProofType idProofType)
        {
            db.IdProofTypes.Attach(idProofType);

            db.Entry(idProofType).State = EntityState.Modified;
             db.SaveChanges();
            return View("id_proof");
        }
    }
}