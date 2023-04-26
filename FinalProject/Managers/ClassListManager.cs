using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Classes;

namespace FinalProject.Managers
{
    class ClassListManager
    {
        public static List<StudentCourses> studentCourseList = new List<StudentCourses>();

        //method to get the list for the listview for the classes
        public static List<Student> GetClassList(string courseID)
        {
            List<Student> classList = new List<Student>();
            Database db = Database.GetInstance();
            if (db.OpenConnection())
            {
                db.cmd = new MySqlCommand($"SELECT id, first, last, email FROM students JOIN student_courses ON (student_courses.student_id = students.id) WHERE student_courses.course_id LIKE \'%{courseID}%\';", db.connection);
                MySqlDataReader reader = db.cmd.ExecuteReader();

                while (reader.Read())
                {
                    classList.Add(new Student(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }

            }
            else
            {
                db.CloseConnection();
                throw new Exception($"No course found with CourseID: {courseID}");
            }
            db.CloseConnection();
            return classList;
        }

        public static List<Course> GetCourseList(string studentID)
        {
            List<Course> courseList = new List<Course>();
            Database db = Database.GetInstance();
            if (db.OpenConnection())
            {
                db.cmd = new MySqlCommand($"SELECT title, courseId, instructor FROM courses JOIN student_courses ON (student_courses.course_id = courses.courseId) WHERE student_courses.student_id LIKE \'%{studentID}%\';", db.connection);
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
