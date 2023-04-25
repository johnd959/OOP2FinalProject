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

        public static void RegisterStudent(Student student, Course course)
        {
            StudentCourses newRegistration = new StudentCourses(student.Id, course.CourseId);
        }
        public static Student SearchStudentById(string id)
        {
            foreach (Student student in Student.StudentList)
            {
                if (student.Id == id) return student;
            }
            return null;
        }
    }
}
