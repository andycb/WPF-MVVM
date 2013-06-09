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
        public void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase
        {
            FindWindow<T>(viewName, model).Show();
        }

        /// <inheritdoc />
        public void OpenWindow<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(null, model).Show();
        }

        /// <inheritdoc />
        public void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase
        {
            FindWindow<T>(viewName, model).ShowDialog();
        }

        /// <inheritdoc />
        public void OpenDialog<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(null, model).ShowDialog();
        }

        /// <summary>
        /// Locates the <see cref="BugViewWindow"/> for a given view model type
        /// </summary>
        /// <typeparam name="T">
        /// The type of view model
        /// </typeparam>
        /// <param name="viewName">
        /// The view name
        /// </param>
        /// <param name="model">
        /// The model
        /// </param>
        /// <returns>The window</returns>
        private WindowView FindWindow<T>(string viewName, object model) where T : ViewModelBase
        {
            var windowName = string.Empty;
            var viewModelName = typeof(T).Name;
            if (!string.IsNullOrEmpty(viewName))
            {
                windowName = viewName;
            }
            else
            {
                windowName = viewModelName.Substring(0, viewModelName.Length - 9) + "Window";
            }

            Debug.WriteLine(string.Format("WindowService.FindWindow :: Looking for window '{0}' for view model '{1}', view name override = '{2}'", windowName, viewModelName, viewName));

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
