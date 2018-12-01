using Basistrainint.RM.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Basistrainint.RM.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
      
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Models.PersonViewModel p = new Models.PersonViewModel();
            return View(p);
        }
        
        public ActionResult AddPerson(FormCollection collection)
        {
            try
            {
                //Basistraining.RM.Comm.Person.Erstellen(collection["firstname"], collection["lastname"]);
                return Redirect("index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create(FormCollection collection)
        {
      
            try
            {
                new Basistraining.RM.Comm.Person
                {
                    firstname = collection["fistname"],
                    lastname = collection["lastname"]
                }.Save();
             //   Basistraining.RM.Comm.Person.Erstellen(collection["firstname"],collection["lastname"]);
                return Redirect("index");
            }
            catch
            {
                return View();
            }
        }
    }
}