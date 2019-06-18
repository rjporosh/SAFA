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
    public class CharitableController : Controller
    {
        // GET: Charitable
        private CharitableRepository _Manager;
      

        public CharitableController()
        {
            _Manager = new CharitableRepository();
            
        }

        string message = "";
        bool status = false;
        public ActionResult add_charitable_fund()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_charitable_fund(CharitableVM vmObj)
        {
            vmObj.CreatedBy = 1;
            vmObj.CreatedDate = DateTime.Now;
            vmObj.UpdatedBy = 1;
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<CharitableFundType>(vmObj);

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
                message = "ReligiousFundType Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }

        }
        public ActionResult charitable_fund()
        {
            return View();
        }
    }
}