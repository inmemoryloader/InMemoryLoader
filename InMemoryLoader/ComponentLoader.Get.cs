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
		/// <param name="AssemblyName">Assembly name.</param>
		/// <param name="ClassName">Class name.</param>
		public IDynamicClassInfo GetClassReference(string AssemblyName, string ClassName)
		{
			if (this.ClassReferences.ContainsKey(AssemblyName) == false)
			{
				Assembly assembly;

				if (this.AssemblyReferences.ContainsKey(AssemblyName) == false)
				{
					this.AssemblyReferences.Add(AssemblyName, assembly = Assembly.LoadFrom(AssemblyName));
				}
				else
				{
					assembly = (Assembly)this.AssemblyReferences[AssemblyName];
				}

				foreach (Type type in assembly.GetTypes())
				{
					if (type.IsClass == true)
					{

						if (type.IsSubclassOf(typeof(AbstractPowerUpComponent)))
						{

							if (type.FullName.EndsWith("." + ClassName))
							{

								IDynamicClassInfo classInfo = new DynamicClassInfo(type, Activator.CreateInstance(type));
								this.ClassReferences.Add(AssemblyName, classInfo);
								return (classInfo);
							}
						}
						else
						{
							throw (new System.Exception("Class is not typeof(AbstractPowerUpComponent)"));
						}
					}
				}
				throw (new System.Exception("Could not instantiate Class"));
			}
			return ((DynamicClassInfo)this.ClassReferences[AssemblyName]);
		}

		/// <summary>
		/// Gets the class reference.
		/// </summary>
		/// <returns>The class reference.</returns>
		/// <param name="paramClassName">Parameter class name.</param>
		public IDynamicClassInfo GetClassReference(string paramClassName)
		{
			var value = this.ClassReferences.Where(cls => cls.Value.ClassType.Name.Contains(paramClassName)).FirstOrDefault();

			if (!string.IsNullOrEmpty(value.Key))
			{
				return value.Value;
			}
			else
			{
				return null;
			}
		}
	}
}