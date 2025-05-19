using System.Windows.Input;
using Models;
using Pages;
using Viewmodels;

namespace Controls;

public partial class MovieInfoBox : ContentView
{
    public static readonly BindableProperty MediaProperty = BindableProperty.Create(nameof(Media), typeof(Media), typeof(MovieInfoBox), null);
    public event EventHandler Closed;
    public MovieInfoBox()
	{
		InitializeComponent();
        ClosedCommand = new Command(ExecuteClosedCommand);
	}
    public Media Media
    {
        get => (Media)GetValue(MediaProperty);
        set => SetValue(MediaProperty, value);
    }
    public ICommand ClosedCommand { get; private set; }
    private void ExecuteClosedCommand() => Closed?.Invoke(this, EventArgs.Empty);
    private void Button_Clicked(object sender, EventArgs e) => Closed?.Invoke(this, EventArgs.Empty);
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var parameters = new Dictionary<string, object>
        {
            [nameof(DetailsPageViewModel.Media)] = Media
        };
        await Shell.Current.GoToAsync(nameof(DetailsPage), true, parameters);
    }
}