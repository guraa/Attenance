using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class ListClasses
    {
        public int Id { get; set; }
        public String ClassName { get; set; }
        public int TeacherId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool IsActive { get; set; }
    }
}