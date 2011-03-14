using System.Linq;
using System.Text;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MbUnit.Framework;
using SharpTestsEx;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when joining elements
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
        [Testing.Row('|')]
        [Testing.Row('*')]
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
            this._actual.Should().Be(this._expected);
        }

        /// <summary>
        /// Creates the expectd string
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._expected = this.Collection
                .Head()
                .Aggregate(new StringBuilder(), (b, x) =>
                                                    {
                                                        b.Append(x);
                                                        b.Append(this._separator);
                                                        return b;
                                                    })
                .Append(this.Collection.Last())
                .ToString();
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