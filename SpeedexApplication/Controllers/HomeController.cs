using SpeedexApplication.Application;
using SpeedexApplication.Models;
using SpeedexApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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


            //var viewModel = new MainMenuGrid();

            IEnumerable<MainMenuGrid> mainMenuGrid = null;

            mainMenuGrid = (from c in db.Customer
                                join a in db.Area on c.AreaId equals a.Id
                                join ci in db.City on a.CityId equals ci.Id
                                select new MainMenuGrid
                                {
                                    FirstName = c.FirstName,                                    
                                    LastName = c.LastName,
                                    Email = c.Email,
                                    Area = a.AreaName,
                                    PostalCode = a.PostCode,
                                    City = ci.Name,
                                    Country = ci.Country
                                });
            //foreach (var item in mainMenuGrid)
            //{
            //    item.FirstName = viewModel.FirstName;

            //}


            //foreach (var item in mainMenuGrid)
            //{
            //    item = viewModel;
            //}

            //var mainMenu = PopulateMainMenuGrid();
            //PopulateMainMenuGrid();
            return View(mainMenuGrid);
        }

        private IEnumerable<Customer> PopulateMainMenuGrid()
        {
            string sqlString = "select c.FirstName as [First Name], c.LastName as [Last Name], c.Email," +
                               " a.AreaName as [Area], a.PostCode as [Postal Code], ci.[Name] as City, " +
                               "ci.Country from Customer c left join Area a on c.AreaId = a.Id " +
                               "left join City ci on ci.Id = a.CityId";
            var mainMenuGrid = db.Customer.SqlQuery(sqlString).ToList();
            //var mainMenuGrid = db.Database.SqlQuery<MainMenuGrid>(sqlString);



            return mainMenuGrid;
        }
    }
}