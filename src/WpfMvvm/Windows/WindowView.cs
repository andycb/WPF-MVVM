namespace WpfMvvm.Windows
{
    using System.Windows;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Base class for a window displayed in the bugView application
    /// </summary>
    public abstract class WindowView : Window
    {
        /// <summary>
        /// Initializes the data context of the window.
        /// </summary>
        /// <param name="viewModel">
        /// The view model
        /// </param>
        public void Initialize(ViewModelBase viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
