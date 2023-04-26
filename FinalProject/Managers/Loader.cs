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
using FinalProject.Classes;

namespace FinalProject.Managers
{
    public class Loader
    {
        public static void Load()
        {

            Database db = Database.GetInstance();
            if(!db.OpenConnection())
            {
                throw new Exception("Unable to connect to database");
            }
            db.cmd = new MySqlCommand("Select * FROM students;", db.connection); 
            MySqlDataReader reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0).Trim();
                string first = reader.GetString(1).Trim();
                string last = reader.GetString(2).Trim();
                string email = reader.GetString(3).Trim();
                string gender = reader.GetString(4).Trim();
                string address = reader.GetString(5).Trim();
                string phone = reader.GetString(6).Trim();

                Student student = new Student(id, first, last, phone, email, gender, address);
            }
            reader.Close(); 
            db.cmd.CommandText = "Select title, courseid, instructor FROM courses;"; 
            reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string title = reader.GetString(0).Trim();
                string courseid = reader.GetString(1).Trim();
                string instructor = reader.GetString(2).Trim();

                Course course = new Course(title, courseid, instructor);
            }
            reader.Close();
            db.cmd.CommandText = "Select student_id, course_id FROM student_courses;";
            reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                string studentid = reader.GetString(0).Trim();
                string courseid = reader.GetString(1).Trim();

                StudentCourses studentcourses = new StudentCourses(studentid, courseid);
            }
            reader.Close();
            db.CloseConnection();
        }
    }
}
