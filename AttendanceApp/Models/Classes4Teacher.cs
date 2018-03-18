using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AttendanceApp.Models
{
    [DataContract]
    public class Classes4Teacher
    {
            public int Id { get; set; }
            public int ClassId { get; set; }
            public String ClassName { get; set; }
     }
}