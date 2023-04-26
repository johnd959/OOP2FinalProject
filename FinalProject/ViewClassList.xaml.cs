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
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
		classesListView.ItemsSource = classList;
    }

}