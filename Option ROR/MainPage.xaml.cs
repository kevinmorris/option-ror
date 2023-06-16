using Microsoft.Maui.Platform;

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

#if ANDROID

        if (Platform.CurrentActivity.CurrentFocus != null)
        {
            Platform.CurrentActivity.ShowKeyboard(Platform.CurrentActivity.CurrentFocus);
        }
#endif
    }

    private void CallPutSwitch_OnToggled(object sender, bool isCall)
    {
        ((MainViewModel)BindingContext).CallPutToggledCommand.Execute(isCall);
    }
}

