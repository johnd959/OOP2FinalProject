namespace FinalProject;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        Controller.Load();
	}
    private void idSearchButton_Clicked(object sender, EventArgs e)
    {
        string idSearch = idSearchEntry.Text;
        Student? found = Controller.SearchStudentById(idSearch);
        if (found != null)
        {
            studentFirstNameEntry.Text = found.First;
            studentLastNameEntry.Text = found.Last;
            studentPhoneEntry.Text = found.Phone;
            studentGenderEntry.Text = found.Gender;
            studentEmailEntry.Text = found.Email;
            studentAddressEntry.Text = found.Address;
        }

    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        idSearchEntry.Text = String.Empty;
        studentFirstNameEntry.Text = String.Empty;
        studentLastNameEntry.Text = String.Empty;
        studentPhoneEntry.Text = String.Empty;
        studentGenderEntry.Text = String.Empty;
        studentEmailEntry.Text = String.Empty;
        studentAddressEntry.Text = String.Empty;
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        string idSearch = idSearchEntry.Text;
        Student? found = Controller.SearchStudentById(idSearch);
        if (found != null)
        {
            found.Phone = studentPhoneEntry.Text;
            found.Gender = studentGenderEntry.Text;
            found.Email = studentEmailEntry.Text;
            found.Address = studentAddressEntry.Text;
        }
        Database db = Database.GetInstance();
        db.Update($"Update students set Phone = \"{found.Phone}\", Gender = \"{found.Gender}\", Email = \"{found.Email}\", Address = \"{found.Address}\" Where id = \"{found.Id}\";");
    }
}

