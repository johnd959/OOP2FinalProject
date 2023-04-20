using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class StudentCourses
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public static List<StudentCourses> studentCourseList = new List<StudentCourses>();

        public StudentCourses(string studentId, string courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
            StudentCourses.studentCourseList.Add(this);
        }

    }
}
