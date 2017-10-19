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
using System.Linq;
using System.Threading;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoader
{
	public abstract class AbstractLoaderBase
	{

		private static readonly ILog log = LogManager.GetLogger(typeof(AbstractLoaderBase));

		public string ApplicationKey = AbstractPowerUpComponent.Key;

		public string AssemblyPath { get; set; }

		public string ConsoleCulture { get; set; }

		public ComponentLoader ComponentLoader { get; set; }

		public AbstractLoaderBase() { }

		public virtual string GetAssemblyPath()
		{
			var compPath = string.Empty;
			compPath = AppDomain.CurrentDomain.BaseDirectory;
			log.DebugFormat("AssemblyPath set to: {0}", this.AssemblyPath);
			return compPath;
		}

		public virtual bool SetInMemoryLoader()
		{
			bool isSet = false;
			this.GetAssemblyPath();
			this.ComponentLoader = ComponentLoader.Instance;
			isSet = true;
			log.DebugFormat("InMemoryLoader set: {0}", isSet);
			return isSet;
		}

		public virtual bool SetClassRegistry()
		{
			bool isSet = false;
			this.ComponentLoader.InitClassRegistry();
			isSet = true;
			log.DebugFormat("ClassRegistry set: {0}", isSet);
			return isSet;
		}

		public virtual bool SetCulture()
		{
			var specificCulture = CultureInfo.CreateSpecificCulture(this.ConsoleCulture);
			var uiCulture = new CultureInfo(this.ConsoleCulture);
			Thread.CurrentThread.CurrentCulture = specificCulture;
			Thread.CurrentThread.CurrentUICulture = uiCulture;
			log.DebugFormat("CurrentCulture set to: {0}", this.ConsoleCulture);
			return true;
		}

	}
}
