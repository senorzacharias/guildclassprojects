using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Data;

namespace HRPortal.Controllers
{
    public class HomeController : Controller
    {
       ApplicantManager manager = new ApplicantManager();
        // GET: Home
        [Route("Application")]
        [HttpGet]
        public ActionResult Apply()
        {
            ApplicationVM viewModel = new ApplicationVM();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Apply(ApplicationVM model)
        {
            manager.AddApplicant(model);

            return RedirectToAction("Complete");
        }

        [HttpGet]
        public ActionResult Complete()
        {
            return View();
        }

       
    }
}