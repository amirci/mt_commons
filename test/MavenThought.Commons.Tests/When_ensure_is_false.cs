using MavenThought.Commons.Testing;
using MbUnit.Framework;
using Assert = MavenThought.Commons.Testing.Assert;

namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Specification when ensure value is false
    /// </summary>
    [Specification]
    public class When_ensure_is_false : EnsureSpecification
    {
        /// <summary>
        /// Checks when value is false throws an exception
        /// </summary>
        [MbUnit.Framework.Test]
        public void Should_throw_an_exception()
        {
            Assert.IsInstanceOfType<EnsureException>(this.ExceptionThrown);
        }

        /// <summary>
        /// Run IsTrue
        /// </summary>
        protected override void WhenIRun()
        {
            this.RegisterException(() => Ensure.IsTrue(1 == 0));
        }
    }
}