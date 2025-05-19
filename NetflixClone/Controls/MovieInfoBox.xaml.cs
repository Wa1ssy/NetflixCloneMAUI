using Models;

namespace Controls;

public partial class MovieInfoBox : ContentView
{
    public static readonly BindableProperty MediaProperty = BindableProperty.Create(nameof(Media), typeof(Media), typeof(MovieInfoBox), null);
    public MovieInfoBox()
	{
		InitializeComponent();
	}
    public Media Media
    {
        get => (Media)GetValue(MediaProperty);
        set => SetValue(MediaProperty, value);
    }
}