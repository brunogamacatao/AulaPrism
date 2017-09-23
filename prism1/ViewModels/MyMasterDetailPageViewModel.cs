using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace prism1.ViewModels
{
    public class MyMasterDetailPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public MyMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
            OnLogout = new Command(Logout);
        }

        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public ICommand OnLogout { get; set; }

        public async void NavigateAsync(string page)
        {
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }

        public async void Logout()
        {
            await _navigationService.NavigateAsync(new Uri("http://br.brunocatao.prism1/CustomNavigationPage/LoginPage", UriKind.Absolute));
        }
    }
}
