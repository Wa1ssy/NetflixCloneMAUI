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
}