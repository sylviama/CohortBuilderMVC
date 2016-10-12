using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerAndRazorReview.DAL.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; }
    }
}