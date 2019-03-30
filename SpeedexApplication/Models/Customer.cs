using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Area> Areas { get; set; }         

        public Customer()
        {
            this.Areas = new HashSet<Area>();            
        }
    }
}