using FinalProject.Managers;
using System.Collections.ObjectModel;
using FinalProject.Classes;

namespace FinalProject;

public partial class ViewClassList : ContentPage
{

	public ViewClassList()
	{
		InitializeComponent();
	}

    //event handler for the course search button on the view class list page
    //takes ina courseID and sends it to ClassListManager to get a classList which can then be used to populate the listview
    private void courseIDSearchButton_Clicked(object sender, EventArgs e)
    {
        List<Student> classList = null;
        try
        {
            if (string.IsNullOrEmpty(courseIDEntry.Text)) 
            { 
                throw new Exception("Search field is empty or invalid"); 
            }
            classList = ClassListManager.GetClassList(courseIDEntry.Text.Trim());
            if (classList.Count == 0)
            {
                throw new Exception($"No students are registered for course ID:{courseIDEntry.Text}");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

		classesListView.ItemsSource = classList;
    }

}