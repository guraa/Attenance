using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using AttendanceApp.SearchModels;

namespace AttendanceApp.Controllers
{
    public class ValuesController : ApiController
    {
       AttendanceContext db = new AttendanceContext();
       
        // GET api/values
        public IHttpActionResult Get(String get)
        {
            var students = db.Students.ToList();
            var teacher = db.Teachers.ToList();
            var enroll = db.Enrolled.ToList();
            var classes = db.Classes.ToList();



            if (students.Count == 0)
                {
                    return Ok("Not found");
                }
             if(get == "all")
            {
                return Ok(students);
            }
             else
            {
                var search = from s in students
                             where s.FirstName == get
                             select new StudentsLogin() { FirstName = s.FirstName, Id = s.Id, LastName = s.LastName, Password = s.Password };

                return Ok(search);

                //var student = from s in students
                //              join e in enroll on s.Id equals e.StudentId
                //              join c in classes on e.ClassId equals Convert.ToInt32(c.Id)
                //              join te in teacher on Convert.ToInt32(c.TeacherId) equals te.Id
                //              where s.FirstName == get
                //              select new StudentsClasses() { StudentName = s.FirstName, Class = c.ClassName, Teacher = te.FirstName };

                //return Ok(student);

            }


        }

        public IHttpActionResult Students(String student)
        {
            var students = db.Students.ToList();

            if (students.Count == 0)
            {
                return Ok("Invalid");
            }
            else
            {

                var search = from s in students
                              where s.FirstName == student
                              select new StudentsLogin() { FirstName = s.FirstName, Id = s.Id,  LastName = s.LastName, Password = s.Password };

                return Ok(search);

            }

        }

            // GET api/values/5
            public string Get(int id)
        {
            return "value";
        }

        // POST api/values

        //Example POST
        //POST /api/values/participate HTTP/1.1
        //Host: localhost:59858
        //Content-Type: application/json
        //Cache-Control: no-cache
        //Postman-Token: d5a3752e-4bbc-db8c-52ea-38e5a140431f

        //    {
	       //     "Id": 1,
	       //     "ClassId" : 2,
	       //     "Code" : "222",
	       //     "StudentId" : 2,
	       //     "Attendance" : 1,
	       //     "StudentMessage" : "It Worked!"
        //    }

    public IHttpActionResult Post([FromBody]Participation participate)
        {
           if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var part = new AttendanceContext())
            {
                part.Participation.Add(new Participation()
                {
                    Id = participate.Id,
                    ClassId = participate.ClassId,
                    Code = participate.Code,
                    DateStamp = DateTime.Now,
                    Attendance = participate.Attendance,
                    StudentId = participate.StudentId,
                    StudentMessage = participate.StudentMessage

                    
                });
                part.SaveChanges();

                return Ok();
                }
            }

        

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
