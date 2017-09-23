using System;
using Prism.Events;
using prism1.Events;
using Xamarin.Forms;

namespace prism1.Pages
{
    public class CustomNavigationPage: NavigationPage
    {
        private IEventAggregator _eventAggregator;

        public CustomNavigationPage(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Subscribe(UpdateColor);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Unsubscribe(UpdateColor);
        }

        void UpdateColor(bool isShowingTheLogin)
        {
            if (isShowingTheLogin)
            {
                this.BarBackgroundColor = Color.Black;
            }
            else
            {
                this.BarBackgroundColor = Color.Red;
            }
        }
    }
}
