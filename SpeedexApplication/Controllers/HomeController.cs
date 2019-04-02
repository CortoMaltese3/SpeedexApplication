using SpeedexApplication.Application;
using SpeedexApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedexApplication.Controllers
{
    public class HomeController : Controller
    {
        private SpeedexContext db = new SpeedexContext();

        public ActionResult Index()
        {

            return View();
        }

        //private void PopulateMainMenuGrid()
        //{
        //    var mainMenuGrid = (from c in db.Customer join ca in db.cust
        //                       join CustomerArea ca on c.Id = ca.CustomerId
        //                 inner
        //                       join Area a on a.Id = ca.AreaId


        //}
    }
}