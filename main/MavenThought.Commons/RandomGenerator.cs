using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Patterns;

namespace MavenThought.Commons
{
    /// <summary>
    /// Utility class to generate random values
    /// </summary>
    public sealed class RandomGenerator
    {

        /// <summary>
        /// Dispatcher to visit the right method using the prefix GenerateRandomXXXX
        /// </summary>
        /// <remarks></remarks>
        private readonly VisitorDispatcher dispatcher = new VisitorDispatcher("GenerateRandom");

        /// <summary>
        /// Random generator of numbers
        /// </summary>
        /// <remarks></remarks>
        private readonly Random random = new Random();

        /// <summary>
        /// Returns an integer between min and max
        /// </summary>
        /// <param name="min">Minimum value to use</param>
        /// <param name="max">Max value to use</param>
        /// <returns>A random integer between values</returns>
        public int Generate(int min, int max)
        {
            return random.Next(min, max);
        }

        /// <summary>
        /// Generic verion to generate a random value
        /// </summary>
        /// <returns>A random value of type T or throws an exception</returns>
        public T Generate<T>()
        {
            return (T) Generate( typeof(T) );
        }

        /// <summary>
        /// Non generic version that calls the dispatcher
        /// </summary>
        /// <param name="rtype">Type of the value to generate</param>
        /// <returns>A new random value of type rtype</returns>
        public object Generate(Type rtype)
        {
            if (rtype.IsEnum)
            {
                var values = Enum.GetValues(rtype);

                var index = random.Next(0, values.Length - 1);

                return values.GetValue(index);
            }

            return dispatcher.Accept(rtype, this, rtype);
        }

        private DateTime GenerateRandomDateTime()
        {
            var result = DateTime.Today.AddDays(random.Next(720));
            var sec = random.Next(86400);
            result = result.AddSeconds(sec);
            return result;
        }

        private double GenerateRandomDouble()
        {
            return random.NextDouble();
        }

        private string GenerateRandomString()
        {
            return random.Next().ToString( );
        }

        private int GenerateRandomInt32()
        {
            return random.Next();
        }

        private bool GenerateRandomBoolean()
        {
            return GenerateRandomInt32() % 2 == 0;
        }

        /// <summary>
        /// Default function to be called if no other is found
        /// </summary>
        /// <param name="type"></param>
        /// <returns>An instance of the specified type created with random values</returns>
        private object GenerateRandomObject(Type type)
        {
            if (type.IsPrimitive)
            {
                throw new NotImplementedException("I don't know how to generate a random Object (no class specified or class not available)");
            }

            var constructors = type.GetConstructors();

            object result = null;

            foreach (var ctr in constructors)
            {
                var parametersInfo = ctr.GetParameters();

                var parameters = parametersInfo.Collect(x => this.Generate(x.ParameterType));

                result = ctr.Invoke(parameters.ToArray());
            }

            return result;
        }

        /// <summary>
        /// Generates a collection of random values
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <returns>A random collection of length size</returns>
        public IEnumerable<T> GenerateCollection<T>(int size)
        {
            return size.Times(() => Generate<T>());
        }
    }
}
