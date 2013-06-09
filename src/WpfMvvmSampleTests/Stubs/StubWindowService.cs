namespace WpfMvvmSampleTests.Stubs
{
    using GalaSoft.MvvmLight;
    using WpfMvvm.Services;

    /// <summary>
    /// Stub implementation of the IWindow service, for use in unit tests.
    /// </summary>
    public class StubWindowService : IWindowService
    {
        /// <inheritdoc />
        public void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase
        {
        }

        /// <inheritdoc />
        public void OpenWindow<T>(object model = null) where T : ViewModelBase
        {
        }

        /// <inheritdoc />
        public void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase
        {
        }

        /// <inheritdoc />
        public void OpenDialog<T>(object model = null) where T : ViewModelBase
        {
        }
    }
}
