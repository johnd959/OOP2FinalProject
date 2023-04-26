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
		coursesListView.ItemsSource = Course.courseList; 
	}

    private void register_Clicked(object sender, EventArgs e)
    {
        string studentID = studentIDEntry.Text;
        string courseID = courseIDEntry.Text;
        string success = Controller.RegisterStudent(studentID, courseID);
        DisplayAlert("Alert", success, "Ok");
        

    }

    private void coursesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {     
        Course selectedItem = e.SelectedItem as Course;
        courseIDEntry.Text = selectedItem.CourseId; 
    }
}