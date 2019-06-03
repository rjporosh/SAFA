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
        string message = "";
        bool status = false;
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
        public JsonResult add_id_proof(IdProofType idProofType)
        {
          
            
            if(ModelState.IsValid)
            {
                idProofType.CreatedDate = DateTime.Now;
                idProofType.UpdatedDate = DateTime.Now;
                idProofType.IsActive = true;
                db.IdProofTypes.Add(idProofType);
                db.SaveChanges();
                    message = "Succesfully Saved";
              
            }
            //isSaved.db.IdProofTypes.Add(idProofType);
           // return new JavaScriptResult { Script = "alert('Successfully registered');" };
            return new JsonResult { Data = new { message = message } };
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