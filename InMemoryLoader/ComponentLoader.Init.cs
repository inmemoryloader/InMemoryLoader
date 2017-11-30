//
// ComponentLoader.Init.cs
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
using System.Collections.Generic;
using System.Linq;

namespace InMemoryLoader
{
	public partial class ComponentLoader
	{
		/// <summary>
		/// Inits the class registry.
		/// </summary>
		/// <returns><c>true</c>, if class registry was inited, <c>false</c> otherwise.</returns>
		public bool InitClassRegistry()
		{
            if (ComponentRegistry == null)
			{
                ComponentRegistry = new Dictionary<IDynamicClassSetup, IDynamicClassInfo>();
			}

			foreach (var item in ClassReferences)
			{

				var dynclass = new DynamicClassSetup();
				dynclass.Assembly = item.Key;
				dynclass.Class = item.Value.ClassType.Name;

				var type = GetClassReference(dynclass.Class);

                if (!ComponentRegistry.Keys.Any(ky => ky.Assembly.Contains(dynclass.Assembly)))
                {
                    ComponentRegistry.Add(dynclass, type);
                    if (log.IsDebugEnabled)
                    {
                        log.DebugFormat("Add AssemblyName: {0}, ClassType.FullName: {1} to ComponentRegistry", dynclass.Assembly, dynclass.Class);
                    }
                }
			}

			if (log.IsDebugEnabled)
			{
                foreach (var item in ComponentRegistry)
				{
					log.InfoFormat("ComponentRegistry contains AssemblyName: {0}, ClassType.FullName: {1}", item.Key.Assembly, item.Key.Class);
				}
			}

			return true;
		}

		/// <summary>
		/// Inits the component.
		/// </summary>
		/// <returns>The component.</returns>
		/// <param name="ClassSetup">Class setup.</param>
		/// <param name="paramArgs">Parameter arguments.</param>
		public Object InitComponent(IDynamicClassSetup ClassSetup, Object[] paramArgs)
		{
			try
			{
				var returnObject = InvokeMethod(ClassSetup.Assembly, ClassSetup.Class, ClassSetup.InitMethod, paramArgs);
				return returnObject;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}