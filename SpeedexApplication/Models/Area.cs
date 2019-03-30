using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class Area : Entity
    {        
        public string AreaName { get; set; }
        public int PostCode { get; set; }      
        public virtual City City { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public Area()
        {
            this.Customers = new HashSet<Customer>();
        }        
    }
}