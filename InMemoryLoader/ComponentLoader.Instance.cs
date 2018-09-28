//
// ComponentLoader.Instance.cs
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

using System.Collections;
using System.Collections.Generic;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoader
{
    /// <summary>
    ///     Component loader.
    /// </summary>
    public partial class ComponentLoader
    {
        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(ComponentLoader));

        /// <summary>
        ///     The instance.
        /// </summary>
        private static volatile ComponentLoader _instance;

        /// <summary>
        ///     The sync root.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        ///     The assembly references.
        /// </summary>
        private readonly Hashtable _assemblyReferences = new Hashtable();

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:InMemoryLoader.ComponentLoader" /> class.
        /// </summary>
        private ComponentLoader()
        {
            ClassReferences = ClassReferences ?? new Dictionary<string, IDynamicClassInfo>();
        }

        /// <summary>
        ///     The class references.
        /// </summary>
        private IDictionary<string, IDynamicClassInfo> ClassReferences { get; }

        /// <summary>
        ///     The component registry.
        /// </summary>
        public IDictionary<IDynamicClassSetup, IDynamicClassInfo> ComponentRegistry { get; set; }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ComponentLoader Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null) _instance = new ComponentLoader();
                    var typename = _instance.GetType();
                    Log.DebugFormat("Create a new instance of Type: {0}", typename);
                }
                return _instance;
            }
        }
    }
}