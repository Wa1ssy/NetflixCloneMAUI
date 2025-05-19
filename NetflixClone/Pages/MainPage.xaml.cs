using Services;
using Viewmodels;

namespace NetflixClone
{
    public partial class MainPage : ContentPage
    {
        private readonly HomeViewModel _vm;

        public MainPage(HomeViewModel vm)
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
        private void MovieRow_MediaSelected(object sender, Controls.MediaSelectEventArgs e)
        {
            _vm.SelectMediaCommand.Execute(e.Media);
        }

        private void MovieInfoBox_Closed(object sender, EventArgs e)
        {
            _vm.SelectMediaCommand.Execute(null);
        }
    }

}
