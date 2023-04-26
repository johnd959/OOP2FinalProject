using System.Collections.ObjectModel;

namespace FinalProject;

public partial class ViewClassList : ContentPage
{

	public ViewClassList()
	{
		InitializeComponent();
	}

    private void courseIDSearchButton_Clicked(object sender, EventArgs e)
    {
		List<Student> classList = Controller.GetClassList(courseIDEntry.Text);
		classesListView.ItemsSource = classList;
    }
}