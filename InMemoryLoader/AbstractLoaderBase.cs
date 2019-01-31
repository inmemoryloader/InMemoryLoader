//
// AbstractLoaderBase.cs
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
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoader
{
    /// <summary>
    ///     AbstractLoaderBase
    ///     Credits to: https://stackoverflow.com/search?q=c%23+dynamic+load+dll
    /// </summary>
    public abstract class AbstractLoaderBase
    {
        private const string Key = AbstractComponent.Key;

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(AbstractLoaderBase));

        /// <summary>
        ///     The ApplicationKey constant
        /// </summary>
        public string ApplicationKey => Key;

        /// <summary>
        ///     Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath { get; set; }

        /// <summary>
        ///     Gets or sets the console culture.
        /// </summary>
        /// <value>The console culture.</value>
        public string ConsoleCulture { get; set; }

        /// <summary>
        ///     Gets or sets the component loader.
        /// </summary>
        /// <value>The component loader.</value>
        public ComponentLoader ComponentLoader { get; set; }

        /// <summary>
        ///     Gets the assembly path.
        /// </summary>
        /// <returns>The assembly path.</returns>
        public virtual string GetAssemblyPath()
        {
            AssemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            Log.DebugFormat("AssemblyPath set to: {0}", AssemblyPath);
            return AssemblyPath;
        }

        /// <summary>
        ///     Sets the in memory loader.
        /// </summary>
        /// <returns><c>true</c>, if InMemoryLoader was set, <c>false</c> otherwise.</returns>
        public virtual bool SetInMemoryLoader()
        {
            GetAssemblyPath();
            ComponentLoader = ComponentLoader.Instance;
            var isSet = ComponentLoader != null;
            Log.DebugFormat("InMemoryLoader set: {0}", isSet);
            return isSet;
        }

        /// <summary>
        ///     Sets the class registry.
        /// </summary>
        /// <returns><c>true</c>, if class registry was set, <c>false</c> otherwise.</returns>
        public virtual bool SetClassRegistry()
        {
            var isSet = ComponentLoader.InitClassRegistry();
            Log.DebugFormat("ClassRegistry set: {0}", isSet);
            return isSet;
        }

        /// <summary>
        ///     Sets the culture.
        /// </summary>
        /// <returns><c>true</c>, if culture was set, <c>false</c> otherwise.</returns>
        public virtual bool SetCulture()
        {
            if (string.IsNullOrEmpty(ConsoleCulture)) throw new ArgumentNullException();
            var specificCulture = CultureInfo.CreateSpecificCulture(ConsoleCulture);
            var uiCulture = new CultureInfo(ConsoleCulture);
            Thread.CurrentThread.CurrentCulture = specificCulture;
            Thread.CurrentThread.CurrentUICulture = uiCulture;
            Log.DebugFormat("CurrentCulture set to: {0}", ConsoleCulture);
            return true;
        }

        /// <summary>
        /// Async execution of InMemoryLoader stuff
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="classInfo">Class info.</param>
        /// <param name="paramObject">Parameter object.</param>
        /// <param name="paramArgs">Parameter arguments.</param>
        public dynamic InvokeMethodAsync(IDynamicClassInfo classInfo, string paramObject, object[] paramArgs)
        {
            if (string.IsNullOrEmpty(paramObject) || classInfo == null || paramArgs.Length == 0) throw new ArgumentNullException();
            return Task.Run(() => ComponentLoader.InvokeMethod(classInfo, paramObject, paramArgs));
        }

    }
}