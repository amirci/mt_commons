using MavenThought.Commons.Logging;
using Microsoft.Practices.Composite.Logging;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Logging
{
    /// <summary>
    /// Specification when the service locator does not have a logger service
    /// </summary>
    [Specification]
    public class When_safe_logger_facade_can_not_get_the_logger_service : SafeLoggerSpecification
    {
        /// <summary>
        /// Actual value obtained
        /// </summary>
        private ILoggerFacade _actual;

        /// <summary>
        /// Checks the default logger is used
        /// </summary>
        [It]
        public void Should_use_the_default_logger_facade()
        {
            Assert.AreSame(SafeLogger.DefaultLogger, this._actual);
        }

        /// <summary>
        /// Setup the default logger facade
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            SafeLogger.DefaultLogger = Mock<ILoggerFacade>();
        }

        /// <summary>
        /// Use the logger
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = SafeLogger.Current;
        }
    }
}