using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Area> Areas { get; set; }

        public City()
        {
            this.Areas = new HashSet<Area>();
        }        
    }}