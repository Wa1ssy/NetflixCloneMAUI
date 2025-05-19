using Services;
using Viewmodels;

namespace NetflixClone
{
    public partial class MainPage : ContentPage
    {
        private readonly HomeViewModel _vm;
        int count = 0;

        public MainPage(HomeViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _vm.InitializeAsync();
        }
    }

}
