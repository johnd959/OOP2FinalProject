using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Course
    {
        public string Title { get; private set; }
        public string CourseId { get; private set; }
        public string Instructor { get; private set; }
        public static List<Course> courseList = new List<Course>();
             

        public Course(string title, string courseId, string instructor)
        {
            Title = title;
            CourseId = courseId;
            Instructor = instructor;
            courseList.Add(this);
        }


    }
}
