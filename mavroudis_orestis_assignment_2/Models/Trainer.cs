using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mavroudis_orestis_assignment_2.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Subject Subject { get; set; }
        public string FullName()
        {
            return (LastName + " " + FirstName);
        }
    }
}