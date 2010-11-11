using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Specification when the value is true
    /// </summary>
    [Specification]
    public class When_ensure_value_is_true : EnsureSpecification
    {
        /// <summary>
        /// Checks when the value is true IsTrue pass
        /// </summary>
        [It]
        public void Should_pass_is_true()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Run IsTrue with true
        /// </summary>
        protected override void WhenIRun()
        {
            Ensure.IsTrue(1 == 1);
        }
    }
}