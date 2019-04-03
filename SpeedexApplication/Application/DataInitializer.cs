using SpeedexApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Application
{
    public class DataInitializer : DropCreateDatabaseAlways<SpeedexContext>
    {
        protected override void Seed(SpeedexContext context)
        {
            IList<City> defaultCities = new List<City>
            {
                new City() { Id = 1, Name = "Athens", Country = "Greece"},
                new City() { Id = 2, Name = "Piraeus", Country = "Greece"},
                new City() { Id = 3, Name = "Paris", Country = "France"},                
            };

            IList<Area> defaultAreas = new List<Area>
            {
                new Area() { Id = 1, AreaName = "Kupseli", PostCode = 11362 , CityId = 1},
                new Area() { Id = 2, AreaName = "Keratsini", PostCode = 18755, CityId = 2 },
                new Area() { Id = 3, AreaName = "Vincennes", PostCode = 11362, CityId = 3}                

            };

            IList<Customer> defaultCustomers = new List<Customer>
            {
                new Customer() { Id = 1, FirstName = "Giorgos", LastName = "Kalomalos", Email = "giorgos.kalomalos@gmail.com", AreaId = 2 },
                new Customer() { Id = 2, FirstName = "Afroditi", LastName = "Karatassou", Email = "afroditi@gmail.com", AreaId = 3 },
                new Customer() { Id = 3, FirstName = "Maria", LastName = "Lagoudi", Email = "maria@gmail.com", AreaId = 1}
            };

            context.City.AddRange(defaultCities);
            context.Area.AddRange(defaultAreas);            
            context.Customer.AddRange(defaultCustomers);

            base.Seed(context);            
        }
    }
}