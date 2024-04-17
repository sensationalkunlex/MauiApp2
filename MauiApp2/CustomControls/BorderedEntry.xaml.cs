namespace MauiApp2.CustomControls;

public partial class BorderedEntry : Grid
{
	public BorderedEntry()
	{
		InitializeComponent();
        
	}

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(BorderedEntry),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(BorderedEntry),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
      propertyName: nameof(Keyboard),
      returnType: typeof(Keyboard),
      declaringType: typeof(BorderedEntry),
      defaultValue: Keyboard.Default,
      defaultBindingMode: BindingMode.OneWay);
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }
    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set { SetValue(KeyboardProperty, value); }
    }
    private void InputEntry_Focused(object sender, FocusEventArgs e)
    {

        PlaceholderLabel.FontSize = 11;
        PlaceholderLabel.TranslateTo(0, -20, 80, easing: Easing.Linear);
    }

    private async void InputEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            PlaceholderLabel.FontSize = 11;
          await  PlaceholderLabel.TranslateTo(0, -20, 80, easing: Easing.Linear);
        }
        else
        {
            PlaceholderLabel.FontSize = 15;
        await    PlaceholderLabel.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }

    private void Frame_Tapped(object sender, EventArgs e)
    {
        InputEntry.Focus();
    }
}