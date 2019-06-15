using AutoMapper;
using SAFA.Models;
using SAFA.Models.ViewModel;
using SAFA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAFA.Controllers
{
    public class InvertsController : Controller
    {
        // GET: Inverts
        private InvertRepository _Manager;


        public InvertsController()
        {
            _Manager = new InvertRepository();
        }

        string message = "";
        bool status = false;
        public ActionResult Inverts()
        {
            return View();
        }
        public ActionResult add_invert()
        {
            return View();
        }
        [HttpPost]

        public JsonResult add_invert(InvertVM vmObj)
        {
            vmObj.CreatedBy = 1;
            vmObj.CreatedDate = DateTime.Now;
            vmObj.UpdatedBy = 1;
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<InvertType>(vmObj);

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
                message = "Religion Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }


        }

    }
}