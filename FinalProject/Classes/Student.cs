using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;

namespace FinalProject.Classes
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

        public Student(string id, string first, string last, string phone, string email, string gender, string address)
        {
            Id = id;
            First = first;
            Last = last;
            Phone = phone;
            Email = email;
            Gender = gender;
            Address = address;
            StudentManager.StudentList.Add(this);
        }
        
        //extra constructor required by the listview objects in ClassList
        public Student(string id, string first, string last, string email)
        {
            Id = id;
            First = first;
            Last = last;
            Email = email;
        }

        //method to update info using key value pairs, corresponds to the updating used by StudentManager
        public void UpdateInfo(KeyValuePair<string, string> info)
        {
            switch (info.Key)
            {
                case "Phone":
                    {
                        this.Phone = info.Value; break;
                    }
                case "Gender":
                    {
                        this.Gender = info.Value; break;
                    }
                case "Email":
                    {
                        this.Email = info.Value; break;
                    }
                case "Address":
                    {
                        this.Address = info.Value; break;
                    }
            }
        }
    }
}
