using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for ToPairs
    /// </summary>
    public abstract class ToPairsSpecification<T>
        : BaseEnumerableSpecification<T>
    {
        protected IEnumerable<Pair<T, T>> Actual { get; set; }
    }
}