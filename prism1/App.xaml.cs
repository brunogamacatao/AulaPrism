 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Navigation;
using Prism.Unity;
using prism1.Pages;
using prism1.Views;
using Xamarin.Forms;

namespace prism1
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(new Uri("/CustomNavigationPage/LoginPage", UriKind.Absolute));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<CustomNavigationPage>();
			Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<MyMasterDetailPage>();
            Container.RegisterTypeForNavigation<MapaPage>();
			Container.RegisterTypeForNavigation<EstadoBateriaPage>();
			Container.RegisterTypeForNavigation<CadastroPage>();
            Container.RegisterTypeForNavigation<ListagemPage>();
        }
    }
}

