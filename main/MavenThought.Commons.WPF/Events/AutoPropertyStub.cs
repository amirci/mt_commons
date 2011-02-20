using System;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Interceptor to set properties using a dictionary
    /// </summary>
    public class AutoPropertyStub : IInterceptor
    {
        /// <summary>
        /// Dictionary to store the properties
        /// </summary>
        private readonly IDictionary<string, object> _properties = new Dictionary<string, object>();

        /// <summary>
        /// Intercepts the invocator of setters and getters
        /// </summary>
        /// <param name="invocation">Invocation to intercept</param>
        public void Intercept(IInvocation invocation)
        {
            if (SetterIsCalled(invocation) || GetterIsCalled(invocation))
            {
                return;
            }

            invocation.Proceed();
        }

        /// <summary>
        /// Checks if is a getter invocation
        /// </summary>
        /// <param name="invocation"></param>
        private bool GetterIsCalled(IInvocation invocation)
        {
            var key = invocation.Method.Name.Substring(4);

            var getterCall = invocation.Method.Name.StartsWith("get_");

            if (getterCall)
            {
                object value;

                _properties.TryGetValue(key, out value);

                if (value == null && invocation.TargetType.IsValueType)
                {
                    value = Activator.CreateInstance(invocation.TargetType);
                }

                invocation.ReturnValue = value;
            }

            return getterCall;
        }

        /// <summary>
        /// Checks if the call is for a setter
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        private bool SetterIsCalled(IInvocation invocation)
        {
            var key = invocation.Method.Name.Substring(4);

            var setterCall = invocation.Method.Name.StartsWith("set_");

            if (setterCall)
            {
                _properties[key] = invocation.Arguments[0];
            }

            return setterCall;
        }
    }
}