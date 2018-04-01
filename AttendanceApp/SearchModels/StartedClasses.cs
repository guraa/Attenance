using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AttendanceApp.Models
{
    [DataContract]
    public class StartedClasses
    {
        public int InitId { get; set; }
        public string Code { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}