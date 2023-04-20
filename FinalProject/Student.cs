using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Student
    {
        public string Id { get; private set; }
        public string First { get;  private set; }
        public string Last { get; private set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
        public string Gender { get; internal set; }
        public string Address { get; internal set; }
        public static List<Student> StudentList = new List<Student>();

        public Student(string id, string first, string last, string phone, string email, string gender, string address)
        {
            Id = id;
            First = first;
            Last = last;
            Phone = phone;
            Email = email;
            Gender = gender;
            Address = address;
            Student.StudentList.Add(this);
        }

        public void Register(Course course)
        {
            Controller.RegisterStudent(this, course);
        }
    }
}
