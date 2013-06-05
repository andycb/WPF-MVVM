namespace WpfMvvm.Services
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using GalaSoft.MvvmLight;
    using Ninject;
    using Ninject.Parameters;
    using WpfMvvm.Windows;

    /// <summary>
    /// Provides window management services to WPF apps in a MVVM compliment way.
    /// </summary>
    public class WindowService : IWindowService
    {
        /// <inheritdoc />
        public void OpenWindow<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(model).Show();
        }

        /// <inheritdoc />
        public void OpenDialog<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(model).ShowDialog();
        }

        /// <summary>
        /// Locates the <see cref="BugViewWindow"/> for a given view model type
        /// </summary>
        /// <typeparam name="T">
        /// The type of view model
        /// </typeparam>
        /// <param name="model">
        /// The model
        /// </param>
        /// <returns>The window</returns>
        private WindowView FindWindow<T>(object model) where T : ViewModelBase
        {
            var viewModelName = typeof(T).Name;
            var windowName = viewModelName.Substring(0, viewModelName.Length - 9) + "Window";
            Debug.WriteLine(string.Format("WindowService.FindWindow :: Looking for window '{0}' for view model '{1}'", viewModelName, windowName));

            var windowType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => typeof(WindowView).IsAssignableFrom(t) && t.Name == windowName);
            if (windowType == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("Unable to find Window for view model {0}", typeof(T)));
            }

            // Inject the model into the ViewModel's constructor
            var modelArgument = new ConstructorArgument("model", model);

            var window = (WindowView)Assembly.GetExecutingAssembly().CreateInstance(windowType.FullName);
            window.Initialize(WpfMvvmApplication.Current.Container.Get<T>(modelArgument));

            return window;
        }
    }
}
