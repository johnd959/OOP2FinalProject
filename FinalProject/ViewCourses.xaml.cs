using Microsoft.Maui.Controls;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace FinalProject;

public partial class ViewCourses : ContentPage
{
    public ViewCourses()
	{
		InitializeComponent();
	}
/*	public static void LoadList()
	{
		foreach(Course course in Course.CourseList)
		{
			Cours += $"{course.CourseId}, {course.Title}, {course.Instructor}";
        }
	}*/
}