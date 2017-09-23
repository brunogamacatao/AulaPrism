using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using prism1.Services;
using Prism.Services;
using System.Windows.Input;
using Prism.Modularity;

namespace prism1.ViewModels
{
    public class EstadoBateriaPageViewModel : BindableBase
    {
		private INavigationService _navigationService;
		private IBatteryService _batteryService;
		private IPageDialogService _pageDialogService;

		public ICommand GetBatteryStatusCommand { get; set; }

		public EstadoBateriaPageViewModel(INavigationService navigationService, 
                                          IBatteryService batteryService, 
                                          IPageDialogService pageDialogService)
		{
			_navigationService = navigationService;
			_batteryService = batteryService;
			_pageDialogService = pageDialogService;

            GetBatteryStatusCommand = new DelegateCommand(GetBatteryStatus).ObservesCanExecute(() => true);
		}

        async void GetBatteryStatus()
		{
			var batteryStatus = _batteryService.GetBatteryStatus();
			await _pageDialogService.DisplayAlertAsync("Battery Status", batteryStatus, "Ok");
		}
    }
}

