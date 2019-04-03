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

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.AreaSortParm = String.IsNullOrEmpty(sortOrder) ? "area_desc" : "";            
            ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";

            var mainMenuGrid = PopulateMainMenuGrid();

            if (!String.IsNullOrEmpty(searchString))
            {
                mainMenuGrid = mainMenuGrid.Where(m => m.LastName.Contains(searchString) || m.Area.Contains(searchString)
                                                   || m.City.Contains(searchString) || m.Country.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(f => f.FirstName);
                    break;
                case "lastName_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(l => l.LastName);
                    break;
                case "email_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(e => e.Email);
                    break;
                case "area_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(a => a.Area);
                    break;
                case "city_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(c => c.City);
                    break;
                case "country_desc":
                    mainMenuGrid = mainMenuGrid.OrderByDescending(c => c.Country);
                    break;
                default:
                    mainMenuGrid = mainMenuGrid.OrderBy(l => l.LastName);
                    break;
            }

            return View(mainMenuGrid.ToList());
        }

        private IEnumerable<MainMenuGrid> PopulateMainMenuGrid()
        {
            IEnumerable<MainMenuGrid> mainMenuGrid = null;

            mainMenuGrid = (from c in db.Customer
                            join a in db.Area on c.AreaId equals a.Id
                            join ci in db.City on a.CityId equals ci.Id
                            select new MainMenuGrid
                            {
                                Id = c.Id,                                
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Email = c.Email,
                                Area = a.AreaName,
                                PostalCode = a.PostCode,
                                City = ci.Name,
                                Country = ci.Country,
                                CityId = ci.Id,
                                AreaId = a.Id
                            });

            return mainMenuGrid;
        }

    }
}