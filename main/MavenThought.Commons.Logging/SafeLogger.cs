using System;
using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.ServiceLocation;

namespace MavenThought.Commons.Logging
{
    /// <summary>
    /// Logger facade class to access safely to the logger
    /// </summary>
    public class SafeLogger
    {
        /// <summary>
        /// Sets the default logger to console
        /// </summary>
        static SafeLogger()
        {
            DefaultLogger = new ConsoleLoggerFacade();    
        }

        /// <summary>
        /// Gets or sets the default logger
        /// </summary>
        public static ILoggerFacade DefaultLogger { get; set; }

        /// <summary>
        /// Gets the logger configured in the service locator or a default one if that fails
        /// </summary>
        public static ILoggerFacade Current
        {
            get
            {
                ILoggerFacade result;

                try
                {
                    result = ServiceLocator.Current.GetInstance<ILoggerFacade>();

                    result = result ?? DefaultLogger;
                }
                catch (Exception)
                {
                    result = DefaultLogger;
                }

                return result;
            }
        }
    }
}
