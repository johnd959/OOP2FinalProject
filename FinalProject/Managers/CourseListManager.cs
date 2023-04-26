using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Classes; 

namespace FinalProject.Managers
{
    class CourseLIstManager
    {
        //method for getting a course list for the listview on viewcourses
        //takes a student id and returns a list of courses for which the student has registered
        public static List<Course> GetCourseList(string studentID)
        {
            List<Course> courseList = new List<Course>();
            Database db = Database.GetInstance();
            if (db.OpenConnection())
            {
                db.cmd = new MySqlCommand($"SELECT title, courseId, instructor FROM courses JOIN student_courses ON (student_courses.course_id = courses.courseId) WHERE student_courses.student_id like \'%{studentID}%\';", db.connection);
                MySqlDataReader reader = db.cmd.ExecuteReader();

                while (reader.Read())
                {
                    courseList.Add(new Course(reader.GetString(0), reader.GetString(1), reader.GetString(2), false));
                }
            }
            else
            {
                db.CloseConnection();
                throw new Exception($"No student found with studentID: {studentID}");
            }
            db.CloseConnection();
            return courseList;
        }
    }
}
