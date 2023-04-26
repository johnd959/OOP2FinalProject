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
            //else create new object and update database
            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(courseID)) 
            {
                db.CloseConnection();
                throw new Exception("StudentID or CourseID field(s) are empty");
            }
            StudentCourses studentCourses = new StudentCourses(studentID, courseID);
            db.cmd = new MySqlCommand($"INSERT INTO student_courses (student_id, course_id) values (\'{studentID}\', \'{courseID}\');", db.connection);
            db.cmd.ExecuteNonQuery();
            db.CloseConnection(); 

            //List<StudentCourses>? existingRegistrationList = new List<StudentCourses>();
            //StudentCourses? foundRegistration = null;
            //foreach (StudentCourses studentCourse in ClassListManager.studentCourseList)
            //{
            //    if (studentCourse.StudentId == studentID)
            //    {
            //        existingRegistrationList.Add(studentCourse);
            //    }
            //}
            //foreach (StudentCourses existingRegistration in existingRegistrationList)
            //{
            //    if (existingRegistration.CourseId == courseID)
            //    {
            //        foundRegistration = existingRegistration;
            //        break;
            //    }
            //}
            //if (foundRegistration != null)
            //{
            //    return "There is already an existing registration with this Student ID and Course ID";
            //}
            //else
            //{
            //    Database db = Database.GetInstance();
            //    new StudentCourses(studentID, courseID);
            //    db.Insert($"INSERT INTO student_courses (student_id, course_id) values (\'{studentID}\', \'{courseID}\');");
            //    return "Registration Successful";
            
        }
    }
}
