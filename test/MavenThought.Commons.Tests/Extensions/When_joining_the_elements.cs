using System.Linq;
using System.Text;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when joinene elements
    /// </summary>
    [Specification]
    public class When_joining_the_elements : JoinSpecification<string>
    {
        /// <summary>
        /// Separator to use
        /// </summary>
        private readonly char _separator;

        /// <summary>
        /// Actual joined value obtained
        /// </summary>
        private string _actual;

        /// <summary>
        /// Expected string
        /// </summary>
        private string _expected;

        /// <summary>
        /// Initializes a new instance of <see cref="When_joining_the_elements"/> class.
        /// </summary>
        /// <param name="separator">Separator to use</param>
        [Row('|')]
        [Row('*')]
        public When_joining_the_elements(char separator)
        {
            this._separator = separator;
        }

        /// <summary>
        /// Checks that the join returns the concatenation of the elements using the separator
        /// </summary>
        [It]
        public void Should_join_all_the_elements()
        {
            Assert.AreEqual(this._expected, this._actual, "The join should match");
        }

        /// <summary>
        /// Creates the expectd string
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var builder = new StringBuilder();

            this.Collection.Head().ForEach(x => builder.Append(x + this._separator));

            builder.Append(this.Collection.Last());

            this._expected = builder.ToString();
        }

        /// <summary>
        /// Join the collection
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.Join(this._separator);
        }
    }
}