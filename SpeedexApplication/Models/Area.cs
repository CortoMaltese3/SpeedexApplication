using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class Area : Entity
    {
        [Required]
        public string AreaName { get; set; }
        [Required]
        public int PostCode { get; set; }
        [Required]
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public Area()
        {
            this.Customers = new HashSet<Customer>();
        }        
    }
}