using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FinalProject.Managers; 

namespace FinalProject.Classes
{
    public class Course
    {
        public string Title { get; private set; }
        public string CourseId { get; private set; }
        public string Instructor { get; private set; }

             

        public Course(string title, string courseId, string instructor, bool create=true)
        {
            Title = title;
            CourseId = courseId;
            Instructor = instructor;
            if (create)
            {
                CoursesManager.courseList.Add(this);
            }            
        }
    }
}
