using System.Windows.Input;
using Viewmodels;
using Models;

namespace Controls;

public class MediaSelectEventArgs : EventArgs
{
    public Media Media { get; set; }
    public MediaSelectEventArgs(Media media) => Media = media;
}

public partial class MovieRow : ContentView
{
    public static readonly BindableProperty HeadingProperty = BindableProperty.Create(nameof(Heading), typeof(string), typeof(MovieRow), string.Empty);

    public static readonly BindableProperty MoviesProperty = BindableProperty.Create(nameof(Movies), typeof(IEnumerable<Media>), typeof(MovieRow), Enumerable.Empty<Media>());

    public static readonly BindableProperty IsLargeProperty = BindableProperty.Create(nameof(IsLarge), typeof(bool), typeof(MovieRow), false);

    public event EventHandler<MediaSelectEventArgs> MediaSelected;

    public MovieRow()
    {
        InitializeComponent();
        MediaDetailsCommand = new Command(ExecuteMediaDetailsCommand);
    }

    public string Heading
    {
        get => (string)GetValue(HeadingProperty);
        set => SetValue(HeadingProperty, value);
    }
    public IEnumerable<Media> Movies
    {
        get => (IEnumerable<Media>)GetValue(MoviesProperty);
        set => SetValue(MoviesProperty, value);
    }
    public bool IsLarge
    {
        get => (bool)GetValue(IsLargeProperty);
        set => SetValue(IsLargeProperty, value);
    }

    public bool IsNotLarge => !IsLarge;

    public ICommand MediaDetailsCommand { get; private set; }
    private void ExecuteMediaDetailsCommand(object parameter)
    {
        if (parameter is Media media && media is not null)
        {
            MediaSelected?.Invoke(this, new MediaSelectEventArgs(media));
        }
    }
}