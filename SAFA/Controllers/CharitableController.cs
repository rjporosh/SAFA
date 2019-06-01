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
        public ActionResult add_charitable_fund()
        {
            return View();
        }
    }
}