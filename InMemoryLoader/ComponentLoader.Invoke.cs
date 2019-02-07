//
// ComponentLoader.Invoke.cs
//
// Author: responsive kaysta
//
// Copyright (c) 2017 responsive kaysta
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Reflection;
using InMemoryLoaderBase;

namespace InMemoryLoader
{
    public partial class ComponentLoader
    {
        /// <summary>
        ///     Invokes the method.
        /// </summary>
        /// <returns>The method.</returns>
        /// <param name="classInfo">Class info.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="paramArgs">Parameter arguments.</param>
        public dynamic InvokeMethod(IDynamicClassInfo classInfo, string methodName, object[] paramArgs)
        {
            try
            {
                var result = classInfo.ClassType.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, classInfo.ClassObject, paramArgs);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Invokes the method.
        /// </summary>
        /// <returns>The method.</returns>
        /// <param name="assemblyName">Assembly name.</param>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="paramArgs">Parameter arguments.</param>
        public dynamic InvokeMethod(string assemblyName, string className, string methodName, object[] paramArgs)
        {
            try
            {
                var classInfo = GetClassReference(assemblyName, className);
                var result = InvokeMethod(classInfo, methodName, paramArgs);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
