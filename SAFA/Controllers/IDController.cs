﻿using AutoMapper;
using SAFA.Models;
using SAFA.Models.ViewModel;
using SAFA.Repository;
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
        
        private IdRepository _Manager;
        SBMDBEntities db = new SBMDBEntities();

        public IDController()
        {
            _Manager = new IdRepository();

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
        public ActionResult add_id_proof(IdVM vmObj)
        {
            vmObj.CreatedBy = 1;
            vmObj.CreatedDate = DateTime.Now;
            vmObj.UpdatedBy = 1;
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<IdProofType>(vmObj);

                result.IsActive = true;

                isSaved = _Manager.Add(result);
                if (isSaved > 0)
                {
                    status = true;
                    message = "Succesfully Saved";
                }
                else
                {
                    status = true;
                    message = "Error! Please try again.";
                }

                return new JsonResult { Data = new { status = status, message = message } };
            }

            else
            {
                status = false;
                message = "IdProofType Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }

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