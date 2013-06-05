namespace WpfMvvmSampleTests.Stubs
{
    using WpfMvvm.Entities;
    using WpfMvvm.Services;

    /// <summary>
    /// Stub implementation of the IMessagebox service for use in unit tests.
    /// </summary>
    public class StubMessageboxService : IMessageboxService
    {
        /// <summary>
        /// Gets or sets the stub result that should be returned by <see cref="ShowMessageBox"/>
        /// </summary>
        public MessageboxResponce StubResult { get; set; }

        /// <inheritdoc />
        public MessageboxResponce ShowMessagebox(string message, MessageboxKind messageboxKind, string title = null)
        {
            // Rather than opening a message box, which would be silly in a test, we return the stub result.
            return this.StubResult;
        }
    }
}
