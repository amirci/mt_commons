using System.IO;
using Microsoft.Practices.Composite.Logging;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Logging.Tests
{
    /// <summary>
    /// Specification when logging a message
    /// </summary>
    [Specification]
    public class When_logger_logs_a_message : Log4NetLoggerSpecification
    {
        /// <summary>
        /// Checks the file is generated
        /// </summary>
        [It]
        public void Should_generate_a_file()
        {
            Assert.IsTrue(File.Exists("error.log"));
        }

        /// <summary>
        /// Log a message
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Log("Test message", Category.Exception, Priority.High);
        }
    }
}