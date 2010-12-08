using System.Reflection;
using log4net;
using Microsoft.Practices.Composite.Logging;

namespace MavenThought.Commons.Logging
{
    /// <summary>
    /// Log4Net implementation of <see cref="ILoggerFacade"/>
    /// </summary>
    public class Log4NetLogger : ILoggerFacade
    {
        /// <summary>
        /// Single instance for the logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Logs a message with a specified category and priority
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="category">Category to use</param>
        /// <param name="priority">Priority to use</param>
        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    Logger.Debug(message);
                    break;

                case Category.Exception:
                    Logger.Error(message);
                    break;

                case Category.Warn:
                    Logger.Warn(message);
                    break;

                default:
                    Logger.Info(message);
                    break;
            }
        }
    }
}