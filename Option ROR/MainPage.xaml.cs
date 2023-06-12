namespace Option_ROR;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Entry_OnFocused(object sender, FocusEventArgs e)
    {
		var entry = (Entry)sender;
        entry.Text = string.Empty;
    }
}

