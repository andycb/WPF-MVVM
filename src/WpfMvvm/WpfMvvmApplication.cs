namespace WpfMvvm
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using Ninject;
    using WpfMvvm.Services;

    /// <summary>
    /// Represents runtime information about the current application
    /// </summary>
    public class WpfMvvmApplication
    {
        /// <summary>
        /// The current application instance
        /// </summary>
        private static WpfMvvmApplication current;

        /// <summary>
        /// Indicates whether the application has been bootstrapped.
        /// </summary>
        private bool hasBootstrapped = false;

        /// <summary>
        /// Prevents a default instance of the WpfMvvmApplication class from being created.
        /// </summary>
        private WpfMvvmApplication()
        {
        }

        /// <summary>
        /// Gets the current application instance
        /// </summary>
        public static WpfMvvmApplication Current
        {
            get
            {
                if (current == null)
                {
                    current = new WpfMvvmApplication();
                }

                return current;
            }
        }

        /// <summary>
        /// Gets the dependency container
        /// </summary>
        public IKernel Container { get; private set; }

        /// <summary>
        /// Bootstraps the application and prepares the dependency container.
        /// </summary>
        public void Bootstrap()
        {
            // Test that the application is in a valid state for bootstrapping
            if (this.hasBootstrapped)
            {
                throw new InvalidOperationException("Illegal attempt to bootstrap the application twice.");
            }

            // Configure the container
            this.Container = new StandardKernel(new DependencyContainer());

            // Register dependencies
            this.Container.Bind<IWindowService>().To<WindowService>();
            this.Container.Bind<IMessageboxService>().To<MessageboxService>();

            // Flag that bootstrap has completed.
            this.hasBootstrapped = true;
        }
    }
}
