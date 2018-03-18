using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp
{
    public class Teachers
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool IsActive { get; set; }
    }
}