using System;
using Castle.Core.Logging;
using Microsoft.Practices.Composite.Logging;

namespace MavenThought.Commons.Logging
{
    /// <summary>
    /// Logger to the console
    /// </summary>
    public class ConsoleLoggerFacade : ILoggerFacade
    {
        /// <summary>
        /// logger backing field
        /// </summary>
        private readonly ILogger _logger = new ConsoleLogger();

        /// <summary>
        /// Logs a message to the console
        /// </summary>
        /// <param name="message">Message to use</param>
        /// <param name="category">Category to use</param>
        /// <param name="priority">Priority of the message</param>
        public void Log(string message, Category category, Priority priority)
        {
            var level = new Action<string>(_logger.Info);

            if (category == Category.Warn)
            {
                level = _logger.Warn;
            }

            if (category == Category.Debug)
            {
                level = _logger.Debug;
            }

            if (category == Category.Exception)
            {
                level = _logger.Error;
            }

            level(message);
        }
    }
}