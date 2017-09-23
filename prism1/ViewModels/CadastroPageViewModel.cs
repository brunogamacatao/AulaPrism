using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using prism1.Models;
using prism1.Services;

namespace prism1.ViewModels
{
    public class CadastroPageViewModel : BindableBase
    {
		private IPageDialogService _pageDialogService;
		private IInfracoesService _infracoesService;

		private string _id;
        private string _usuario;
        private string _descricao;
        private bool _isLoading = false;

        public ICommand OnAdicionaCommand { get; set; }

        public CadastroPageViewModel(IPageDialogService pageDialogService, 
                                  IInfracoesService infracoesService) 
        {
            _pageDialogService = pageDialogService;
            _infracoesService = infracoesService;
            OnAdicionaCommand = new DelegateCommand(Adiciona).ObservesCanExecute(() => FormularioValido);
        }

        public async void Adiciona()
        {
            IsLoading = true;

            var novaInfracao = await _infracoesService.Adiciona(new Infracao() {
                Id = Id,
                Usuario = Usuario,
                Descricao = Descricao
            });

            IsLoading = false;

            Id = "";
            Usuario = "";
            Descricao = "";

            await _pageDialogService.DisplayAlertAsync("Infração Registrada", "Nova Infração Registrada", "Ok");
        }

        public bool FormularioValido { get; set; } = true;

		public string Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		public string Usuario
		{
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
		}

		public string Descricao
		{
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
		}

		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}        
	}
}
