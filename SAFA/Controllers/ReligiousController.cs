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
    public class ReligiousController : Controller
    {
        // GET: Religious
        
        private ReligiousFundRepository _Manager;
        private ReligionRepository _Manager1;

        public ReligiousController()
        {
            _Manager = new ReligiousFundRepository();
            _Manager1 = new ReligionRepository();
        }

        string message = "";
        bool status = false;
        public ActionResult add_religion()
        {
            return View();
        }
        public ActionResult religious_fund()
        {
            return View();
        }
        [HttpPost]

        public JsonResult add_religion(ReligionVM vmObj)
        {
            vmObj.CreatedBy = 1;
            vmObj.CreatedDate = DateTime.Now;
            vmObj.UpdatedBy = 1;
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<Religion>(vmObj);

                result.IsActive = true;

                isSaved = _Manager1.Add(result);
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
                message = "Bank Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }


        }
        [HttpPost]

        public JsonResult Create( ReligiousFundVM vmObj)
        {

         //   vmObj.CreatedBy = "porosh";
            vmObj.CreatedDate = DateTime.Now;
          //  vmObj.UpdatedBy = "tf";
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<ReligiousFundType>(vmObj);

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
                message = "Name Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }




        }


        public ActionResult add_religious_fund()
        {
            return View();
        }

        public JsonResult GetByAjax()
        {
            var var = _Manager.Read().ToList();

            var MDirectorList = Mapper.Map<List<ReligiousFundVM>>(var);

            return new JsonResult { Data = MDirectorList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        // ********** TEST END *****************//

        public JsonResult GetbyID(int? id)
        {



            var var = _Manager.Read().SingleOrDefault(m => m.ReligiousFundTypeId == id);


            var result = Mapper.Map<ReligiousFundVM>(var);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult Edit(ReligiousFundVM vmObj)
        {

            var result = Mapper.Map<ReligiousFundType>(vmObj);


            result.IsActive = true; // 

            int isUpdated = _Manager.Update(result);


            if (isUpdated > 0)
            {

                status = true;

                message = "Updated Successfully!!";


            }
            else
            {

                status = false;

                message = "Error In Update!!";
            }


            return new JsonResult { Data = new { status = status, message = message } };
        }

        public ActionResult Delete(int? id)
        {
            var var = _Manager.Read().SingleOrDefault(m => m.ReligiousFundTypeId == id);

            int isDeleted = _Manager.Delete(var);

            message = "This Item Deleted Successfully!!";

            return new JsonResult { Data = new { status = isDeleted, message = message } };


        }
    }
}