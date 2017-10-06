using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using prism1.Models;
using prism1.Services;
using Xamarin.Forms;

namespace prism1.ViewModels
{
    public class CadastroPageViewModel : BindableBase
    {
		private IPageDialogService _pageDialogService;
		private IInfracoesService _infracoesService;

		private string _id;
        private string _descricao;
        private bool _isLoading = false;
        private bool _temFoto = false;
        private ImageSource _fotoSource;

        private System.IO.Stream photoStream;

        public ICommand OnAdicionaCommand { get; set; }
        public ICommand OnTirarFotoCommand { get; set; }

        public CadastroPageViewModel(IPageDialogService pageDialogService, 
                                  IInfracoesService infracoesService) 
        {
            _pageDialogService = pageDialogService;
            _infracoesService = infracoesService;
            OnAdicionaCommand = new DelegateCommand(Adiciona).ObservesCanExecute(() => FormularioValido);
            OnTirarFotoCommand = new DelegateCommand(TirarFoto).ObservesCanExecute(() => FormularioValido);
        }

        public async void Adiciona()
        {
            IsLoading = true;

            var novaInfracao = await _infracoesService.Adiciona(new Infracao() {
                Id = Id,
                Descricao = Descricao
            }, photoStream);

            IsLoading = false;

            Id = "";
            Descricao = "";

            await _pageDialogService.DisplayAlertAsync("Infração Registrada", "Nova Infração Registrada", "Ok");
        }

        public async void TirarFoto()
        {
			var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
				photoStream = photo.GetStream();
                //FotoSource = ImageSource.FromStream(() => photoStream);
                //TemFoto = true;
			}
		}

        public bool FormularioValido { get; set; } = true;

		public string Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
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

		public bool TemFoto
		{
            get { return _temFoto; }
			set { SetProperty(ref _temFoto, value); }
		}

        public ImageSource FotoSource
		{
            get { return _fotoSource; }
			set { SetProperty(ref _fotoSource, value); }
		}
	}
}
