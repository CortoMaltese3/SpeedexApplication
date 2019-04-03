using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SpeedexApplication.Models;

namespace SpeedexApplication.ViewModel
{
    public class MainMenuGrid : Entity
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Area { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }



        //public MainMenuGrid(Customer customer, Area area, City city)
        //{
        //    FirstName = customer.FirstName;
        //    LastName = customer.LastName;
        //    Email = customer.Email;
        //    Area = area.AreaName;
        //    PostalCode = area.PostCode;
        //    City = city.Name;
        //    Country = city.Country;

        //}

        //public IEnumerable<Customer> Customers { get; set; }
        //public IEnumerable<Area> Areas { get; set; }
        //public IEnumerable<City> Cities { get; set; }

    }
}