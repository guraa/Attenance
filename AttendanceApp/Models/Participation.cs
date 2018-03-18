using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceApp
{
    public class Participation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime DateStamp { get; set; }
        public String Code { get; set; }
        public bool Attendance { get; set; }
        public string StudentMessage { get; set; }
    }
}