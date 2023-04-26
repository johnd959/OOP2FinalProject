using Microsoft.Maui.Controls;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using FinalProject.Managers;
using FinalProject.Classes;

namespace FinalProject;

public partial class ViewCourses : ContentPage
{
    public ViewCourses()
	{
		InitializeComponent();

	}

    //event handler for the register button, takes the student id and the course id and sends it to CourseManager to create a new Student_Courses object
 
    private void register_Clicked(object sender, EventArgs e)
    {
        try
        {
            CoursesManager.RegisterStudent(studentIDEntry.Text, courseIDEntry.Text);
            DisplayAlert("Alert", "Student successfully registered", "Ok");
        }
        catch(Exception ex)
        {
            DisplayAlert("Error", $"{ex.Message}", "OK");
        }
        
    }

    //event handler for taking the courseID from the selected list view cell and populating the courseID entry
    private void coursesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {     
        Course selectedItem = e.SelectedItem as Course;
        courseIDEntry.Text = selectedItem.CourseId; 
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        coursesListView.ItemsSource = CoursesManager.courseList;
    }
}