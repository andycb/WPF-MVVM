namespace WpfMvvm.Messages
{
    /// <summary>
    /// Message sent between windows to display text.
    /// </summary>
    public class ShowTextMessage
    {
        /// <summary>
        /// Initializes a new instance of the ShowTextMessage class.	
        /// </summary>
        /// <param name="text">
        /// The message text
        /// </param>
        public ShowTextMessage(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets the message text
        /// </summary>
        public string Text { get; private set; }
    }
}
