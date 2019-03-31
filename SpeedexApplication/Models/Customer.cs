using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedexApplication.Models
{
    public class Customer : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }        
        public ICollection<Area> Areas { get; set; }         

        public Customer()
        {
            this.Areas = new HashSet<Area>();            
        }
    }
}