using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAFA.Controllers
{
    public class IDController : Controller
    {
        // GET: ID
        public ActionResult id_proof()
        {
            return View();
        }
        public ActionResult add_id_proof()
        {
            return View();
        }
    }
}