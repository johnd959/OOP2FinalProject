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
		coursesListView.ItemsSource = CoursesManager.courseList; 
	}

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

    private void coursesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {     
        Course selectedItem = e.SelectedItem as Course;
        courseIDEntry.Text = selectedItem.CourseId; 
    }
}