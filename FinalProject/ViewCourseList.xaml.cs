using FinalProject.Managers;
using FinalProject.Classes;

namespace FinalProject;

public partial class ViewCourseList : ContentPage
{
	public ViewCourseList()
	{
		InitializeComponent();
	}

    // the event handler for the student ID search on the view couses page
    //takes a student id and sends it to CourseLIstManager to get a list of courses to which a student has registered to populate the list view
    private void studentIDSearchButton_Clicked(object sender, EventArgs e)
    {
        List<Course> courseList = null;
        try
        {
            if (string.IsNullOrEmpty(studentIDEntry.Text))
            {
                throw new Exception("Search field is empty or invalid");
            }
            courseList = CourseLIstManager.GetCourseList(studentIDEntry.Text.Trim());
            if (courseList.Count == 0)
            {
                throw new Exception($"No courses found for student ID: {studentIDEntry.Text}");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

        coursesListView.ItemsSource = courseList;
    }
}