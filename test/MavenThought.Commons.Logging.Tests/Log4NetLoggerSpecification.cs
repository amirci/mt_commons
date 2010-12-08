using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Logging.Tests
{
    /// <summary>
    /// Base specification for Log4NetLogger
    /// </summary>
    public abstract class Log4NetLoggerSpecification
        : AutoMockSpecificationWithNoContract<Log4NetLogger>
    {
        /// <summary>
        /// Initializes the configuration
        /// </summary>
        protected override void GivenThat()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}