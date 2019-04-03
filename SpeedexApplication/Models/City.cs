using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class City : Entity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        
    }
}