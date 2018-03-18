using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp
{

    //Teachers have more than one class linked
    public class Classes
    {
        public int Id { get; set; }
        public String ClassName { get; set; }
        public int TeacherId { get; set; }
    }
}