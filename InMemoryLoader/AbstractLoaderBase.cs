//
// AbstractLoaderBase.cs
//
// Author: Kay Stuckenschmidt <mailto.kaysta@gmail.com>
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
using System.Globalization;
using System.Threading;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoader
{
    /// <summary>
    /// AbstractLoaderBase
    /// </summary>
	public abstract class AbstractLoaderBase
	{
		/// <summary>
		/// The log.
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(typeof(AbstractLoaderBase));

		/// <summary>
		/// The application key.
		/// </summary>
		public string ApplicationKey = AbstractPowerUpComponent.Key;

		/// <summary>
		/// Gets or sets the assembly path.
		/// </summary>
		/// <value>The assembly path.</value>
		public string AssemblyPath { get; set; }
		/// <summary>
		/// Gets or sets the console culture.
		/// </summary>
		/// <value>The console culture.</value>
		public string ConsoleCulture { get; set; }
		/// <summary>
		/// Gets or sets the component loader.
		/// </summary>
		/// <value>The component loader.</value>
		public ComponentLoader ComponentLoader { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:InMemoryLoader.AbstractLoaderBase"/> class.
		/// </summary>
		public AbstractLoaderBase() { }

		/// <summary>
		/// Gets the assembly path.
		/// </summary>
		/// <returns>The assembly path.</returns>
		public virtual string GetAssemblyPath()
		{
			var compPath = string.Empty;
			compPath = AppDomain.CurrentDomain.BaseDirectory;
            Log.DebugFormat("AssemblyPath set to: {0}", AssemblyPath);
			return compPath;
		}

		/// <summary>
		/// Sets the in memory loader.
		/// </summary>
		/// <returns><c>true</c>, if in memory loader was set, <c>false</c> otherwise.</returns>
		public virtual bool SetInMemoryLoader()
		{
			bool isSet = false;
			GetAssemblyPath();
			ComponentLoader = ComponentLoader.Instance;
			isSet = true;
            Log.DebugFormat("InMemoryLoader set: {0}", isSet);
			return isSet;
		}

		/// <summary>
		/// Sets the class registry.
		/// </summary>
		/// <returns><c>true</c>, if class registry was set, <c>false</c> otherwise.</returns>
		public virtual bool SetClassRegistry()
		{
			bool isSet = false;
			ComponentLoader.InitClassRegistry();
			isSet = true;
            Log.DebugFormat("ClassRegistry set: {0}", isSet);
			return isSet;
		}

		/// <summary>
		/// Sets the culture.
		/// </summary>
		/// <returns><c>true</c>, if culture was set, <c>false</c> otherwise.</returns>
		public virtual bool SetCulture()
		{
			var specificCulture = CultureInfo.CreateSpecificCulture(ConsoleCulture);
			var uiCulture = new CultureInfo(ConsoleCulture);
			Thread.CurrentThread.CurrentCulture = specificCulture;
			Thread.CurrentThread.CurrentUICulture = uiCulture;
            Log.DebugFormat("CurrentCulture set to: {0}", ConsoleCulture);
			return true;
		}

	}

}
