using FinalProject.Managers;
using FinalProject.Classes;

namespace FinalProject;

public partial class ViewCourseList : ContentPage
{
	public ViewCourseList()
	{
		InitializeComponent();
	}
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
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
        coursesListView.ItemsSource = courseList;
    }
}