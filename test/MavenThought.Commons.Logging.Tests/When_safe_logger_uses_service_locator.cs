using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.ServiceLocation;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Logging.Tests
{
    /// <summary>
    /// Specification when using the service locator
    /// </summary>
    [Specification]
    public class When_safe_logger_uses_service_locator : SafeLoggerSpecification
    {
        /// <summary>
        /// Actual value obtained
        /// </summary>
        private ILoggerFacade _actual;

        /// <summary>
        /// Expected logger
        /// </summary>
        private ILoggerFacade _expected;

        /// <summary>
        /// Checks the default logger is used
        /// </summary>
        [It]
        public void Should_use_the_service()
        {
            Assert.AreSame(this._expected, this._actual);
        }

        /// <summary>
        /// Setup the default logger facade
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var locator = Mock<IServiceLocator>();

            ServiceLocator.SetLocatorProvider(() => locator);

            _expected = Mock<ILoggerFacade>();
            locator.Stub(l => l.GetInstance<ILoggerFacade>()).Return(_expected);
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