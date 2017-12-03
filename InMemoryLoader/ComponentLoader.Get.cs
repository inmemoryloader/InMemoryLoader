//
// ComponentLoader.Get.cs
//
// Author: Kay Stuckenschmidt <mailto.kaysta@gmail.com>
//
// Copyright (c) 2017 responsive-kaysta
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

using InMemoryLoaderBase;
using System;
using System.Linq;
using System.Reflection;

namespace InMemoryLoader
{
    public partial class ComponentLoader
    {
        /// <summary>
        /// Gets the class reference.
        /// </summary>
        /// <returns>The class reference.</returns>
        /// <param name="assemblyName">Assembly name.</param>
        /// <param name="className">Class name.</param>
		public IDynamicClassInfo GetClassReference(string assemblyName, string className)
        {
            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(className))
            {
                throw new ArgumentNullException();
            }

            if (ClassReferences.ContainsKey(assemblyName) == false)
            {
                Assembly assembly;

                if (_assemblyReferences.ContainsKey(assemblyName) == false)
                {
                    _assemblyReferences.Add(assemblyName, assembly = Assembly.LoadFrom(assemblyName));
                }
                else
                {
                    assembly = (Assembly)_assemblyReferences[assemblyName];
                }

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && type.IsPublic && type.FullName.EndsWith("." + className, StringComparison.InvariantCultureIgnoreCase))
                    {
                        IDynamicClassInfo classInfo = new DynamicClassInfo(type, Activator.CreateInstance(type));

                        if (typeof(InMemoryLoaderBase.AbstractPowerUpComponent).IsAssignableFrom(classInfo.ClassType))
                        {
                            ClassReferences.Add(assemblyName, classInfo);
                            return (classInfo);
                        }
                        else
                        {
                            throw (new System.Exception("Class is not typeof(InMemoryLoaderBase.AbstractPowerUpComponent)"));
                        }
                    }
                }
                throw (new System.Exception("Could not instantiate Class"));
            }
            return ((DynamicClassInfo)ClassReferences[assemblyName]);
        }

        /// <summary>
        /// Gets the class reference.
        /// </summary>
        /// <returns>The class reference.</returns>
        /// <param name="paramClassName">Parameter class name.</param>
        public IDynamicClassInfo GetClassReference(string paramClassName)
        {
            var value = ClassReferences.FirstOrDefault(cls => cls.Value.ClassType.Name.Contains(paramClassName));
            return !string.IsNullOrEmpty(value.Key) ? value.Value : null;
        }
    }
}