using System;
using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for Enumerable
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    [Row(typeof(double))]
    public abstract class BaseEnumerableSpecification<T>
        : BaseSpecification
    {
        /// <summary>
        /// Gets or sets the collection to use in the specification
        /// </summary>
        protected IEnumerable<T> Collection { get; set; }

        /// <summary>
        /// Gets or sets the predicate to use
        /// </summary>
        protected Predicate<T> Predicate { get; set; }

        /// <summary>
        /// Factory for test types
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> TestTypesFactory()
        {
            yield return typeof(int);
            yield return typeof(string);
            yield return typeof(DateTime);
            yield return typeof(long);
            yield return typeof(double);
        }

        /// <summary>
        /// Setup the collection
        /// </summary>
        protected override void GivenThat()
        {
            this.Collection = new RandomGenerator().GenerateCollection<T>(100);
        }
    }
}