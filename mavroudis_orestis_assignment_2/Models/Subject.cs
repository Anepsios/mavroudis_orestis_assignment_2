using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mavroudis_orestis_assignment_2.Models
{
    public enum Subject
    {
        [Display(Name = "C#")]
        CSharp, 
        Java, 
        Javascript, 
        Python
    }
}