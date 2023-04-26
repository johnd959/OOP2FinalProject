using FinalProject.Managers;
using FinalProject.Classes;

namespace FinalProject;
public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        try
        {
            Loader.Load();
        }
        catch(Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
	}
    // method for searching a student and populating the fields with their information
    private void idSearchButton_Clicked(object sender, EventArgs e)
    {
        string idSearch = idSearchEntry.Text;
        Student? found = StudentManager.SearchStudentById(idSearch);
        if (found != null)
        {
            studentFirstNameEntry.Text = found.First;
            studentLastNameEntry.Text = found.Last;
            studentPhoneEntry.Text = found.Phone;
            studentGenderEntry.Text = found.Gender;
            studentEmailEntry.Text = found.Email;
            studentAddressEntry.Text = found.Address;
        }
        else
        {
            DisplayAlert("Error", "Student not found", "Ok");
            ClearEntries();
        }

    }
    // method for quickly clearing the fields all at once
    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        ClearEntries();
    }

    private void ClearEntries()
    {
        idSearchEntry.Text = String.Empty;
        studentFirstNameEntry.Text = String.Empty;
        studentLastNameEntry.Text = String.Empty;
        studentPhoneEntry.Text = String.Empty;
        studentGenderEntry.Text = String.Empty;
        studentEmailEntry.Text = String.Empty;
        studentAddressEntry.Text = String.Empty;
    }

    //event handler for the save button
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        Dictionary<string, string> newInfo = new Dictionary<string, string>()
        {
            {"Phone", $"{studentPhoneEntry.Text.Trim()}" },
            {"Gender", $"{studentGenderEntry.Text.Trim()}" },
            {"Email", $"{studentEmailEntry.Text.Trim()}" },
            {"Address", $"{studentAddressEntry.Text.Trim()}" }
        };
        try
        {
            if (CheckFields(newInfo)) { throw new Exception("One ore more of the fields are empty"); }
            StudentManager.Save(idSearchEntry.Text.Trim(), newInfo);
            DisplayAlert("Alert", "Successfully saved", "OK");


            
        }
        catch (Exception ex1)
        {
            DisplayAlert("Error", $"{ex1.Message}", "OK");
        }
    }

    private void createButton_Clicked(object sender, EventArgs e)
    {
        Dictionary<string, string> newInfo = new Dictionary<string, string>()
        {
            {"First", studentFirstNameEntry.Text.Trim()},
            {"Last", studentLastNameEntry.Text.Trim()},
            {"Phone", $"{studentPhoneEntry.Text.Trim()}" },
            {"Gender", $"{studentGenderEntry.Text.Trim()}" },
            {"Email", $"{studentEmailEntry.Text.Trim()}" },
            {"Address", $"{studentAddressEntry.Text.Trim()}" }
        };
        try
        {
            if (CheckFields(newInfo)) {throw new Exception("One or more of the fields are empty"); }
            StudentManager.Create(idSearchEntry.Text.Trim(), newInfo);
            DisplayAlert("Alert", "Successfully created", "OK");

        }
        catch (Exception ex1)
        {
            DisplayAlert("Error", $"{ex1.Message}", "OK");
        }
    }
    private bool CheckFields(Dictionary<string, string> fields)
    {
        foreach (KeyValuePair<string, string> kvp in fields)
        {
            if (kvp.Value.Equals(string.Empty))
            {
                return true;
            }
        }
        return false; 
    }
}

