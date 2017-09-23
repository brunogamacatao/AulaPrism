using System;
using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Navigation;
using prism1.Models;
using prism1.Services;

namespace prism1.ViewModels
{
    public class ListagemPageViewModel : BindableBase, INavigationAware
    {
        private IInfracoesService _infracoesService;
        private IEnumerable<Infracao> _infracoes = new List<Infracao>();
        private bool _isLoading = false;

        public ListagemPageViewModel(IInfracoesService infracoesService)
        {
            _infracoesService = infracoesService;
        }

        public IEnumerable<Infracao> Infracoes
		{
			get { return _infracoes; }
			set { SetProperty(ref _infracoes, value); }
		}

		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            CarregaInfracoes();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        private async void CarregaInfracoes()
        {
            IsLoading = true;
            Infracoes = await _infracoesService.Lista();
            IsLoading = false;
        }
    }
}
