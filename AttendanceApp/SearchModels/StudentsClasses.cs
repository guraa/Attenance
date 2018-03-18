using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AttendanceApp.SearchModels
{
    [DataContract]
    public class StudentsClasses
    {

            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string Class { get; set; }
            [DataMember]
            public string Teacher { get; set; }
        
    }
}