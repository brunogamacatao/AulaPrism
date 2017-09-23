using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Prism.Unity;
using Microsoft.Practices.Unity;
using prism1.Droid.Services;
using prism1.Services;

namespace prism1.Droid
{
    [Activity(Label = "prism1.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

			LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        static BatteryService batteryService = new BatteryService();
        static AutenticacaoService autenticacaoService = new AutenticacaoService();
        static InfracoesService infracoesService = new InfracoesService(autenticacaoService);

        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<IBatteryService>(batteryService, new ExternallyControlledLifetimeManager());
            container.RegisterInstance<IAutenticacaoService>(autenticacaoService, new ExternallyControlledLifetimeManager());
            container.RegisterInstance<IInfracoesService>(infracoesService, new ExternallyControlledLifetimeManager());
        }
    }
}
