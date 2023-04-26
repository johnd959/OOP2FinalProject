using Microsoft.Maui.ApplicationModel.Communication;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace FinalProject
{
    public class Controller
    {
        public static void Load()
        {
            Database db = Database.GetInstance();
            db.OpenConnection();
            db.cmd = new MySqlCommand("Select * FROM students;", db.connection); 
            MySqlDataReader reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string first = reader.GetString(1);
                string last = reader.GetString(2);
                string email = reader.GetString(3);
                string gender = reader.GetString(4);
                string address = reader.GetString(5);
                string phone = reader.GetString(6);

                Student student = new Student(id, first, last, phone, email, gender, address);
            }
            reader.Close(); 
            db.cmd.CommandText = "Select title, courseid, instructor FROM courses;"; 
            reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string title = reader.GetString(0);
                string courseid = reader.GetString(1);
                string instructor = reader.GetString(2);

                Course course = new Course(title, courseid, instructor);
            }
            reader.Close();
            db.cmd.CommandText = "Select student_id, course_id FROM student_courses;";
            reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string studentid = reader.GetString(0);
                string courseid = reader.GetString(1);

                StudentCourses studentcourses = new StudentCourses(studentid, courseid);
            }
            reader.Close();
            db.CloseConnection();
        }

        public static string RegisterStudent(string studentID, string courseID)
        {
            List<StudentCourses>? existingRegistrationList = new List<StudentCourses>();
            StudentCourses? foundRegistration = null;
            foreach(StudentCourses studentCourse in StudentCourses.studentCourseList)
            {
                if (studentCourse.StudentId == studentID)
                {
                    existingRegistrationList.Add(studentCourse);
                }
            }
            foreach(StudentCourses existingRegistration in existingRegistrationList)
            {
                if (existingRegistration.CourseId == courseID)
                {
                    foundRegistration = existingRegistration;
                    break;
                }
            }
            if (foundRegistration != null)
            {
                return "There is already an existing registration with this Student ID and Course ID";
            }
            else
            {
                Database db = Database.GetInstance();
                new StudentCourses(studentID, courseID);
                db.Insert($"INSERT INTO student_courses (student_id, course_id) values (\'{studentID}\', \'{courseID}\');");
                return "Registration Successful"; 
            }
        }
        public static Student SearchStudentById(string id)
        {
            foreach (Student student in Student.StudentList)
            {
                if (student.Id == id) return student;
            }
            return null;
        }
        public static List<Student> GetClassList(string courseID)
        {
            List<Student> classList = new List<Student>();
            Database db = Database.GetInstance();
            db.OpenConnection();
            db.cmd = new MySqlCommand($"SELECT id, first, last, email FROM students JOIN student_courses ON (student_courses.student_id = students.id) WHERE student_courses.course_id LIKE '%{courseID}%';", db.connection);
            MySqlDataReader reader = db.cmd.ExecuteReader();

            while (reader.Read())
            {
                classList.Add(new Student(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            db.CloseConnection();
            return classList;
        }
    }
}
