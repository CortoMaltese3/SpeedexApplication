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
        [Display(Name = "Area")]
        [MaxLength(100)]
        public string AreaName { get; set; }

        [Required]        
        [Display(Name = "Postal Code")]
        [Range(10000,99999)]
        public int PostCode { get; set; }
        
        public virtual City City { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}