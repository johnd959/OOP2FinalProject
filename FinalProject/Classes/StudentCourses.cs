﻿using FinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    internal class StudentCourses
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }


        public StudentCourses(string studentId, string courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
            ClassListManager.studentCourseList.Add(this);
        }

    }
}

