using Prism.Events;
using prism1.Events;
using Xamarin.Forms;

namespace prism1.Views
{
    public partial class LoginPage : ContentPage
    {
        private IEventAggregator _eventAggregator;

        public LoginPage(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            InitializeComponent();
        }

		protected override void OnAppearing()
		{
            base.OnAppearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Publish(true);
		}

        protected override void OnDisappearing() 
        {
            base.OnDisappearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Publish(false);
        }
	}
}

