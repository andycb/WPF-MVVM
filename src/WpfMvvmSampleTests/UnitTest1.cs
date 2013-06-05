namespace WpfMvvmSampleTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    using WpfMvvm;
    using WpfMvvm.Entities;
    using WpfMvvm.Services;
    using WpfMvvm.ViewModels;

    using WpfMvvmSampleTests.Stubs;

    /// <summary>
    /// Sample unit tests to show how services can be rebound at test time with stub implantations, that isolate tests from native UI functions such a message boxes.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// The main view model being tested
        /// </summary>
        private MainViewModel mainViewModel;

        /// <summary>
        /// The stub message box service
        /// </summary>
        private StubMessageboxService stubMessageboxService;

        /// <summary>
        /// Sample test method
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            // Set up the stub message box service to do what we want
            this.stubMessageboxService.StubResult = MessageboxResponce.Yes;
            this.mainViewModel.ShowMessageCommand.Execute(null);
        }

        /// <summary>
        /// Sets up the test environment
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Force the application to bootstrap itself.
            WpfMvvmApplication.Current.Bootstrap();

            // Replace the WPF specific Window and Message box services with stub classes that the tests can work with.
            // You could easily use Moq or Fakes here if you want.
            WpfMvvmApplication.Current.Container.Rebind<IWindowService>().To<StubWindowService>();

            this.stubMessageboxService = new StubMessageboxService();
            WpfMvvmApplication.Current.Container.Rebind<IMessageboxService>().ToConstant(this.stubMessageboxService);

            // Initialise the view model being tested.
            this.mainViewModel = WpfMvvmApplication.Current.Container.Get<MainViewModel>();
        }
    }
}
