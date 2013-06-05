namespace WpfMvvm
{
    using System.Windows;
    using Ninject;

    using WpfMvvm.Models;
    using WpfMvvm.Services;
    using WpfMvvm.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            WpfMvvmApplication.Current.Bootstrap();

            var mainModel = new SampleModel("This text is retrieved from the model, which is injected as a named constructor argument to the ViewModel");
            WpfMvvmApplication.Current.Container.Get<IWindowService>().OpenWindow<MainViewModel>(mainModel);
        }
    }
}
