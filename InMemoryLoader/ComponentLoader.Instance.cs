﻿//
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

using InMemoryLoaderBase;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InMemoryLoader
{
    /// <summary>
    /// Component loader.
    /// </summary>
    public partial class ComponentLoader
    {
        /// <summary>
        /// The log.
        /// </summary>
        readonly static ILog Log = LogManager.GetLogger(typeof(ComponentLoader));

        /// <summary>
        /// The instance.
        /// </summary>
        static volatile ComponentLoader _instance;

        /// <summary>
        /// The sync root.
        /// </summary>
        readonly static object SyncRoot = new Object();

        /// <summary>
        /// The assembly references.
        /// </summary>
        readonly Hashtable _assemblyReferences = new Hashtable();

        /// <summary>
        /// The class references.
        /// </summary>
        IDictionary<string, IDynamicClassInfo> ClassReferences;

        /// <summary>
        /// The component registry.
        /// </summary>
        public IDictionary<IDynamicClassSetup, IDynamicClassInfo> ComponentRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InMemoryLoader.ComponentLoader"/> class.
        /// </summary>
        ComponentLoader()
        {
            ClassReferences = ClassReferences ?? new Dictionary<string, IDynamicClassInfo>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ComponentLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ComponentLoader();
                            Log.DebugFormat("Create a new instance of Type: {0}", _instance.GetType());
                        }
                    }
                }

                return _instance;
            }
        }
    }
}