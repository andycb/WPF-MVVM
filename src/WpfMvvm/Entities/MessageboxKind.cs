namespace WpfMvvm.Entities
{
    /// <summary>
    /// The kind of message box that should be shown
    /// </summary>
    public enum MessageboxKind
    {
        /// <summary>
        /// Only an OK button is shown.
        /// </summary>
        Ok = 0,

        /// <summary>
        /// An OK and cancel button are shown.
        /// </summary>
        OKCancel,

        /// <summary>
        /// Yes no and cancel buttons are shown.
        /// </summary>
        YesNoCancel,
        
        /// <summary>
        /// Yes and no buttons are shown.
        /// </summary>
        YesNo
    }
}
