using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MavenThought.Commons.Extensions
{
    public static class Expressions
    {
        /// <summary>
        /// Createst the property changed event args based on a expression for a property
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="property">property to use</param>
        /// <returns>A property changed event args for the name of the property used</returns>
        public static PropertyChangedEventArgs CreateChangeEventArgs<T>(this Expression<Func<T>> property)
        {
            return new PropertyChangedEventArgs(property.GetPropertyName());
        }

        /// <summary>
        /// Returns the name of the property
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="property">Expression to get the property name</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<T>(this Expression<Func<T>> property)
        {
            var memberExpr = property.Body as MemberExpression;
            var methodExpr = property.Body as MethodCallExpression;

            Ensure.IsTrue(memberExpr != null || methodExpr != null);

            return memberExpr == null ? methodExpr.Method.Name : memberExpr.Member.Name;
        }
    }
}