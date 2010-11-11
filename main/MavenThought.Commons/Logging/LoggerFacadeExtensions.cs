using System;
using System.Globalization;
using Microsoft.Practices.Composite.Logging;

namespace MavenThought.Commons.Logging
{
    /// <summary>
    /// Extension methods for ILogginFacada interface
    /// </summary>
    public static class LoggerFacadeExtensions
    {
        /// <summary>
        /// Generates an Info message
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Info(this ILoggerFacade facade, string msg, params object[] args)
        {
            facade.Info(Priority.Low, msg, args);
        }

        /// <summary>
        /// Generates a warning in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="culture">Culture to use when formatting the message</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Info(this ILoggerFacade facade, IFormatProvider culture, Priority priority, string msg, params object[] args)
        {
            LogIt(facade, culture, priority, Category.Info, msg, args);
        }

        /// <summary>
        /// Generates an info message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Info(this ILoggerFacade facade, Priority priority, string msg, params object[] args)
        {
            facade.Warn(CultureInfo.CurrentCulture, priority, msg, args);
        }
        
        /// <summary>
        /// Generates a warning in the log with the message and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Warn(this ILoggerFacade facade, string msg, params object[] args)
        {
            facade.Warn(Priority.Low, msg, args);
        }

        /// <summary>
        /// Generates a warning in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Warn(this ILoggerFacade facade, Priority priority, string msg, params object[] args)
        {
            facade.Warn(CultureInfo.CurrentCulture, priority, msg, args);
        }

        /// <summary>
        /// Generates a warning in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="culture">Culture to use when formatting the message</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Warn(this ILoggerFacade facade, IFormatProvider culture, Priority priority, string msg, params object[] args)
        {
            LogIt(facade, culture, priority, Category.Warn, msg, args);
        }

        /// <summary>
        /// Generates a debug entry in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Debug(this ILoggerFacade facade, string msg, params object[] args)
        {
            facade.Debug(Priority.Low, msg, args);
        }

        /// <summary>
        /// Generates a debug entry in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Debug(this ILoggerFacade facade, Priority priority, string msg, params object[] args)
        {
            facade.Debug(CultureInfo.CurrentCulture, priority, msg, args);
        }

        /// <summary>
        /// Generates an error in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="culture">Culture to use when formatting</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Debug(this ILoggerFacade facade, IFormatProvider culture, Priority priority, string msg, params object[] args)
        {
            LogIt(facade, culture, priority, Category.Debug, msg, args);
        }

        /// <summary>
        /// Generates an Error entry in the log for the exception
        /// </summary>
        /// <param name="facade">Facade to use</param>
        /// <param name="e">Exception to log</param>
        public static void Error(this ILoggerFacade facade, Exception e)
        {
            facade.Error(Priority.Low, e.Message);
            facade.Error(Priority.Low, e.StackTrace);

            var inner = e.InnerException;

            if (inner != null)
            {
                facade.Error(inner);
            }
        }

        public static void Error(this ILoggerFacade facade, string msg, params object[] args)
        {
            facade.Error(Priority.Low, msg, args);
        }

        /// <summary>
        /// Generates an error entry in the log with the message, priority and arguments specified
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Error(this ILoggerFacade facade, Priority priority, string msg, params object[] args)
        {
            facade.Error(CultureInfo.CurrentCulture, priority, msg, args);
        }
        
        /// <summary>
        /// Generates an error entry in the log with the parameters specified
        /// </summary>
        /// <param name="facade">Log to use</param>
        /// <param name="culture">Culture info to use</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void Error(this ILoggerFacade facade, IFormatProvider culture, Priority priority, string msg, params object[] args)
        {
            LogIt(facade, culture, priority, Category.Exception, msg, args);
        }

        /// <summary>
        /// Class utility method to generate an entry in the log with the specified category message and culture
        /// </summary>
        /// <param name="facade">Logger facade to use</param>
        /// <param name="culture">Culture to use when formatting</param>
        /// <param name="priority">Priority to use</param>
        /// <param name="cat">Category to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        private static void LogIt(ILoggerFacade facade, IFormatProvider culture, Priority priority, Category cat, string msg, params object[] args)
        {
            facade.Log(string.Format(culture, msg, args), cat, priority);
        }
    }
}