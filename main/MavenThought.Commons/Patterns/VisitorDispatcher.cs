using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MavenThought.Commons.Delegates;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.Patterns
{
    /// <summary>
    /// Visitor pattern using a dynamic dispatcher for the methods
    /// to call VisitXXXX based on the source suplied as target
    /// for the visitor
    /// </summary>
    public class VisitorDispatcher
    {
        /// <summary>
        /// Prefix to use when looking up methods
        /// </summary>
        private readonly string _methodPrefix = "Visit";

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitorDispatcher"/> class. 
        /// </summary>
        /// <remarks>
        /// Calls the constructor with the prefix "Visit" 
        /// </remarks>
        public VisitorDispatcher()
            : this("Visit")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitorDispatcher"/> class. 
        /// </summary>
        /// <param name="prefix">
        /// The new prefix to use instead of "Visit"
        /// </param>
        public VisitorDispatcher(string prefix)
        {
            this._methodPrefix = prefix;
        }

        /// <summary>
        /// Accepts a visitor a calls the VisitXXXX matching object using the type name.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the source (any)
        /// </typeparam>
        /// <param name="source">
        /// The source object to invoke the VisitXXXX method
        /// </param>
        /// <param name="visitor">
        /// The visitor to use
        /// </param>
        /// <param name="args">
        /// The optional arguments to use
        /// </param>
        /// <remarks>
        /// Returns the result of calling the method in the visitor or null if the method was not found
        /// </remarks>
        /// <returns>
        /// The accept.
        /// </returns>
        public object Accept<T>(T source, object visitor, params object[] args)
        {
            var sourceType = source as Type ?? typeof(T);

            var name = sourceType.Name;

            if (sourceType.IsEnum && !(source is Type))
            {
                name = Enum.GetName(sourceType, source);
            }

            var visitorType = visitor.GetType();

            // Find the method with the args
            var memberInfo = this.FindMethod(visitorType, name, args);

            // If null try with no args
            memberInfo = this.IfNullTryWithNoArgs(memberInfo, visitorType, name, ref args);

            // If null try for "VisitObject" method
            memberInfo = this.IfNullTryWithObject(memberInfo, visitorType, args);

            return memberInfo == null ? null : GuardedInvokation(memberInfo, visitor, args);
        }

        /// <summary>
        /// Checks for null and tries to find the VisitObject method
        /// </summary>
        /// <param name="info">Method info to use</param>
        /// <param name="visitorType">Type of the visitor</param>
        /// <param name="args">Args to match when visiting</param>
        /// <returns>The MethodInfo found or null if not found</returns>
        private MethodInfo IfNullTryWithObject(MethodInfo info, Type visitorType, object[] args)
        {
            var result = info;

            if (info == null)
            {
                result = this.FindMethod(visitorType, "Object", args);
            }

            return result;
        }

        /// <summary>
        /// Finds the method  methodPrefix + name in the type  using the args specified
        /// </summary>
        /// <param name="visitorType">The target type to search</param>
        /// <param name="name">The method name</param>
        /// <param name="args">The arguments for the method</param>
        /// <returns>A method info with the specified prefix + name that receives the specified arguments or null if not found</returns>
        private MethodInfo FindMethod(Type visitorType, string name, params object[] args)
        {
            var result = visitorType.GetMethod(this._methodPrefix + name, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, ArgumentTypes(args), null);

            return result;
        }

        /// <summary>
        /// Iterates thru the elements invoking the dispatcher
        /// </summary>
        /// <param name="collection">The collection to visit</param>
        /// <param name="visitor" >The visitor to use</param>
        /// <param name="args">Additional arguments</param>
        public void AcceptAll<T>(IEnumerable<T> collection, object visitor,  params object[] args)
        {
            collection.ForEach( x => this.Accept(x, visitor, args));
        }

        /// <summary>
        /// Catches the targetInvocationException around the invoke to propagate the inner exception
        /// </summary>
        /// <param name="method">The method to call</param>
        /// <param name="visitor">The instance to use</param>
        /// <param name="args">Arguments for the call</param>
        private static object GuardedInvokation(MethodInfo method, object visitor,  params object[] args)
        {
            try
            {
                return method.Invoke(visitor, args);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Gets all the types of the arguments
        /// </summary>
        /// <param name="args">The array to get the types from</param>
        /// <returns>An array with the type of the arguments</returns>
        private static Type[] ArgumentTypes(IEnumerable<object> args)
        {
            return args.Collect(FunctorHelper.GetClassType<object>()).ToArray();
        }

        /// <summary>
        /// If the method info is null tries to find one with no args, if succeds then updates the method info and the args
        /// </summary>
        /// <param name="info">
        /// The method info to check for null
        /// </param>
        /// <param name="visitor">
        /// The type of the visitor
        /// </param>
        /// <param name="methodName">
        /// The method name to look for
        /// </param>
        /// <param name="args">
        /// The arguments return
        /// </param>
        /// <remarks>
        /// If the method info is null tries to find a method "methodName" with no arguments
        /// </remarks>
        /// <returns>
        /// The if null try with no args.
        /// </returns>
        private MethodInfo IfNullTryWithNoArgs(MethodInfo info, Type visitor, string methodName, ref object[] args)
        {
            var result = info;

            if (info == null)
            {
                result = this.FindMethod(visitor, methodName, new object[] { });

                if (result != null)
                {
                    args = new object[] { };
                }
            }

            return result;
        }
    }
}