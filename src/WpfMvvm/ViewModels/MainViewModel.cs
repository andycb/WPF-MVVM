namespace WpfMvvm.ViewModels
{
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using WpfMvvm.Entities;
    using WpfMvvm.Models;
    using WpfMvvm.Services;

    /// <summary>
    /// The view model for the main Window
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The window service
        /// </summary>
        private readonly IWindowService windowService;

        /// <summary>
        /// The message box service
        /// </summary>
        private readonly IMessageboxService messageboxService;

        /// <summary>
        /// THe model
        /// </summary>
        private readonly SampleModel model;

        /// <summary>
        /// The user's' name
        /// </summary>
        private string nameInput;

        /// <summary>
        /// The greeting text
        /// </summary>
        private string greetingText = string.Empty;

        /// <summary>
        /// Some test text
        /// </summary>
        private string demoText;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="model">
        /// The model
        /// </param>
        /// <param name="windowService">
        /// The window service
        /// </param>
        /// <param name="messageboxService">
        /// The message box service
        /// </param>
        public MainViewModel(object model, IWindowService windowService, IMessageboxService messageboxService)
        {
            this.windowService = windowService;
            this.messageboxService = messageboxService;
            this.model = (SampleModel)model;

            this.Set(() => this.DemoText, ref this.demoText, "This text is bound to a property on the view model, when you click the button the view model will change the value using the Set() method. This will automatically call RaisePropertyChanged on the property and cause the UI to update.");
        }

        /// <summary>
        /// Gets some text from the model
        /// </summary>
        public string ModelText 
        {
            get
            {
                return this.model != null ? this.model.Message : "The model is optional, this is the same Window, however no model was supplied.";
            }
        }

        /// <summary>
        /// Gets some text text to prove this view model works
        /// </summary>
        public string DemoText
        {
            get
            {
                return this.demoText;
            }

            private set
            {
                this.demoText = value;
            }
        }

        /// <summary>
        /// Gets the command for a test button
        /// </summary>
        public ICommand ChangeTextCommand
        {
            get
            {
                return new RelayCommand(() => this.Set(() => this.DemoText, ref this.demoText, "...The button was clicked."));
            }
        }

        /// <summary>
        /// Gets the open window command
        /// </summary>
        public ICommand OpenWindowCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenWindow<MainViewModel>());
            }
        }

        /// <summary>
        /// Gets the open dialog command
        /// </summary>
        public ICommand OpenDialogCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenDialog<MainViewModel>());
            }
        }

        /// <summary>
        /// Gets the show message command
        /// </summary>
        public ICommand ShowMessageCommand
        {
            get
            {
                return new RelayCommand(() => this.messageboxService.ShowMessagebox("Message text", MessageboxKind.YesNo,  "Message title"));
            }
        }

        /// <summary>
        /// Gets the open alternative window command
        /// </summary>
        public ICommand OpenAlternativeWindowCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenWindow<MainViewModel>("AlternativeWindow"));
            }
        }

        /// <summary>
        /// Gets or sets the user's name
        /// </summary>
        public string NameInput
        {
            get
            {
                return this.nameInput;
            }

            set
            {
                this.Set(() => this.NameInput, ref this.nameInput, value);
                this.GreetingText = string.Format("Hello, {0}", value);
            }
        }

        /// <summary>
        /// Gets or sets the greeting text
        /// </summary>
        public string GreetingText
        {
            get
            {
                return this.greetingText;
            }

            set
            {
                this.Set(() => this.GreetingText, ref this.greetingText, value);
            }
        }
    }
}