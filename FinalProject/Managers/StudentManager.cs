using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using FinalProject.Classes; 

namespace FinalProject.Managers
{
    class StudentManager
    {
        public static List<Student> StudentList = new List<Student>();

        //Method to search a student by their id
        public static Student SearchStudentById(string id)
        {
            foreach (Student student in StudentList)
            {
                if (student.Id == id) return student;
            }
            return null;
        }
        //method to save any updates to the student list 
        public static void Save(string idSearch, Dictionary<string, string> newInfo)
        {
            Student? found = SearchStudentById(idSearch);
            if (string.IsNullOrEmpty(idSearch))
            {
                throw new Exception("Id is null or empty");
            }
            else if (found == null)
            {
                throw new Exception($"No student with ID: {idSearch} found");
            }
            Database db = Database.GetInstance();
            db.OpenConnection();
            foreach (KeyValuePair<string, string> kvp in newInfo)
            {
                found.UpdateInfo(kvp);
                db.cmd = new MySqlCommand($"UPDATE students set {kvp.Key.ToLower()}=\'{kvp.Value}\' WHERE id=\'{idSearch}\';", db.connection);
                db.cmd.ExecuteNonQuery(); 
            }
            db.CloseConnection();
        }

        //method to create a new student object and insert it into the database
        public static void Create(string id, Dictionary<string, string> info)
        {
            Database db = Database.GetInstance();
            db.OpenConnection();
            db.cmd = new MySqlCommand($"SELECT * FROM students WHERE id = \'{id}\';", db.connection);
            MySqlDataReader reader = db.cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!string.IsNullOrEmpty(reader.GetString(0)))
                {
                    reader.Close();
                    db.CloseConnection();
                    throw new Exception($"Student with ID:{id} already exists");
                }
            }
            reader.Close();
            db.CloseConnection();  
            new Student(id, info["First"], info["Last"], info["Phone"], info["Email"], info["Gender"], info["Address"]);

            try
            {
                db.Insert($"INSERT INTO students (id, first, last, email, gender, address, phone) VALUES (\'{id}\', " +
    $"\'{info["First"]}\', \'{info["Last"]}\', \'{info["Email"]}\', \'{info["Gender"]}\', \'{info["Address"]}\', \'{info["Phone"]}\');");
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception(ex.Message);
            }
        }
    }
}
