using System;

namespace MavenThought.Commons.Delegates
{
    /// <summary>
    /// Utility class declaration for predicate helpers
    /// </summary>
    public partial class Predicates
    {

        /// <summary>
        /// Returns a binary predicate to compare equality
        /// </summary>
        /// <typeparam name="T1">First type parameter</typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns>result where forAll( x, y : result( x, y ) implies x equals y )</returns>
        public static Predicate<T1, T2> IsEqualTo<T1, T2>()
        {
            return (x, y) => Equals(x, y);
        }

        /// <summary>
        /// Returns a unary predicate to check if an int is even
        /// </summary>
        /// <returns>result where forAll( x : result( x ) implies x is even )</returns>
        public static Predicate<long> IsEven( ) 
        {
            return x => x % 2 == 0;
        }

        /// <summary>
        /// Returns a unary predicate to check if an int is odd
        /// </summary>
        /// <returns>result where forAll( x : result( x ) implies x is odd )</returns>
        public static Predicate<long> IsOdd()
        {
            return x => x % 2 != 0;
        }

        /// <summary>
        /// Returns a binary predicate to check if x > y
        /// </summary>
        /// <typeparam name="T">Type of the predicate (IComparable)</typeparam>
        /// <returns>result where forAll( T x, T y : result( x, y ) implies x is greater than y )</returns>
        public static Predicate<T, T> IsGreaterThan<T>() where T: IComparable<T>
        {
            return (x, y) => x.CompareTo( y ) > 0;
        }


        /// <summary>
        /// Returns a binary predicate to check if x < y
        /// </summary>
        /// <typeparam name="T">Type of the predicate (IComparable)</typeparam>
        /// <returns>result where forAll( T x, T y : result( x, y ) implies x is less than y )</returns>
        public static Predicate<T, T> IsLessThan<T>() where T : IComparable<T>
        {
            return (x, y) => x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Returns a binary predicate to check if x >= y
        /// </summary>
        /// <typeparam name="T">Type of the predicate (IComparable)</typeparam>
        /// <returns>result where forAll( T x, T y : result( x, y ) implies x is greater or equal than y )</returns>
        public static Predicate<T, T> IsGreaterOrEqualThan<T>() where T : IComparable<T>
        {
            return (x, y) => x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Returns a binary predicate to check if x <= y
        /// </summary>
        /// <typeparam name="T">Type of the predicate (IComparable)</typeparam>
        /// <returns>result where forAll( T x, T y : result( x, y ) implies x is less or equal than y )</returns>
        public static Predicate<T, T> IsLessOrEqualThan<T>() where T : IComparable<T>
        {
            return (x, y) => x.CompareTo(y) <= 0;
        }


    }
}