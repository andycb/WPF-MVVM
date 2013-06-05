namespace WpfMvvm.Models
{
    /// <summary>
    /// A sample model that may be passed to a single or multiple view models, or may be passed between them by means of state retention.
    /// </summary>
    public class SampleModel
    {
        /// <summary>
        /// Initializes a new instance of the SampleModel class.
        /// </summary>
        /// <param name="message">The message</param>
        public SampleModel(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets the message
        /// </summary>
        public string Message { get; private set; }
    }
}
