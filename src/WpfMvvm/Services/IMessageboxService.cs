namespace WpfMvvm.Services
{
    using WpfMvvm.Entities;

    /// <summary>
    /// Defines functionality for the displaying of message boxes
    /// </summary>
    public interface IMessageboxService
    {
        /// <summary>
        /// Shows a message box, and blocks until it is closed.
        /// </summary>
        /// <param name="message">The message to shown in the message box</param>
        /// <param name="messageboxKind">The kind of message box to display</param>
        /// <param name="title">The title of the message box window</param>
        /// <returns>The button that the user clicked</returns>
        MessageboxResponce ShowMessagebox(string message, MessageboxKind messageboxKind, string title = null);
    }
}
