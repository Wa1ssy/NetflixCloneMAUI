using Viewmodels;

namespace Pages;

public partial class DetailsPage : ContentPage
{
    private readonly DetailsPageViewModel _vm;

    public DetailsPage(DetailsPageViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitializeAsync();
    }
    private void TrailersTab_Tapped(object sender, TappedEventArgs e)
    {
        similarTabIndicator.Color = Colors.Black;
        similarTabContent.IsVisible = false;

        trailersTabIndicator.Color = Colors.Red;
        trailersTabContent.IsVisible = true;
    }

    private void SimilarTab_Tapped(object sender, TappedEventArgs e)
    {
        trailersTabIndicator.Color = Colors.Black;
        trailersTabContent.IsVisible = false;

        similarTabIndicator.Color = Colors.Red;
        similarTabContent.IsVisible = true;
    }
}