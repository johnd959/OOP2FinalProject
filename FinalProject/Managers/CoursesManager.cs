using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Classes; 

namespace FinalProject.Managers
{
    class CoursesManager
    {
        public static List<Course> courseList = new List<Course>();

        //method to register student
        //takes studentID and courseID and creates a new student_Courses object 
        //also writes the same information to the database
        public static void RegisterStudent(string studentID, string courseID)
        {
            // querying database to check for existing registration
            Database db = Database.GetInstance();
            db.OpenConnection();
            db.cmd = new MySqlCommand($"SELECT * FROM student_courses WHERE student_id=\'{studentID}\' AND course_id=\'{courseID}\';", db.connection);
            MySqlDataReader reader = db.cmd.ExecuteReader();
            string? foundID = null;
            while (reader.Read())
            {
                foundID = reader.GetString(0); 
                if(foundID != string.Empty)
                {
                    //throw exception if exists
                    reader.Close();
                    db.CloseConnection();
                    throw new Exception("Student has already been registered for this course");
                    
                }
            }
            reader.Close();
            db.CloseConnection();
            //else create new object and update database
            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(courseID)) 
            {
                db.CloseConnection();
                throw new Exception("StudentID or CourseID field(s) are empty");
            }
            StudentCourses studentCourses = new StudentCourses(studentID, courseID);
            db.Insert($"INSERT INTO student_courses (student_id, course_id) values (\'{studentID}\', \'{courseID}\');");
        }
    }
}
