namespace WpfMvvm.Services
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Defines the Window service functionality.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Opens the window for a given view model type
        /// </summary>
        /// <typeparam name="T">
        /// The view model type
        /// </typeparam>
        /// <param name="viewName">
        /// The name of a the view to open.
        /// </param>
        /// <param name="model">
        /// The model to pass to the view model
        /// </param>
        void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase;

        /// <summary>
        /// Opens the window for a given view model type
        /// </summary>
        /// <typeparam name="T">
        /// The view model type
        /// </typeparam>
        /// <param name="model">
        /// The model to pass to the view model
        /// </param>
        void OpenWindow<T>(object model = null) where T : ViewModelBase;

        /// <summary>
        /// Opens the window for a given view model type as a dialogue
        /// </summary>
        /// <typeparam name="T">
        /// The view model type
        /// </typeparam>
        /// <param name="viewName">
        /// The name of a the view to open.
        /// </param>
        /// <param name="model">
        /// The model to pass to the view model
        /// </param>
        void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase;

        /// <summary>
        /// Opens the window for a given view model type as a dialogue
        /// </summary>
        /// <typeparam name="T">
        /// The view model type
        /// </typeparam>
        /// <param name="model">
        /// The model to pass to the view model
        /// </param>
        void OpenDialog<T>(object model = null) where T : ViewModelBase;
    }
}
