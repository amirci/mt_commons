using MbUnit.Framework;

namespace MavenThought.Commons.Tests.Delegates
{
    public abstract class BaseSpecification: BaseTestWithMocking
    {
        [SetUp]
        public virtual void Before_Each()
        {
            this.Because();
        }

        /// <summary>
        /// Holder before each tests
        /// </summary>
        protected virtual void Because() {}
    }
}