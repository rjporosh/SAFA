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
    public class BankController : Controller
    {
        // GET: Bank
        private BankRepository _Manager;
        SBMDBEntities db = new SBMDBEntities();

        public BankController()
        {
            _Manager = new BankRepository();

        }

        string message = "";
        bool status = false;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult paymentType()
        {
            return View();
        }
        public ActionResult add_paymentType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_id_proof(PaymentTypeVM vmObj)
        {
            vmObj.CreatedBy = 1;
            vmObj.CreatedDate = DateTime.Now;
            vmObj.UpdatedBy = 1;
            vmObj.UpdatedDate = DateTime.Now;


            int isSaved = 0;

            if (ModelState.IsValid)
            {


                var result = Mapper.Map<PaymentType>(vmObj);

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
                message = "PaymentType Allready Exsists !!!";
                return new JsonResult { Data = new { status = status, message = message } };
            }

        }
    }
}