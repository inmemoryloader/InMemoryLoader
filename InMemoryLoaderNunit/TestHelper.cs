﻿//
// TestHelper.cs
//
// Author: responsive kaysta <me@responsive-kaysta.ch>
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
using InMemoryLoader;

namespace InMemoryLoaderNunit
{
    /// <summary>
    /// Test helper.
    /// </summary>
    internal class TestHelper : AbstractLoaderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestHelper"/> class.
        /// </summary>
        /// <param name="culture">Culture.</param>
        /// <param name="path">Path.</param>
        internal TestHelper(string culture, string path)
        {
            base.ConsoleCulture = culture;
            base.AssemblyPath = path;
        }

        /// <summary>
        /// Determines whether this instance is assembly path set.
        /// </summary>
        /// <returns><c>true</c> if this instance is assembly path set; otherwise, <c>false</c>.</returns>
        internal bool IsAssemblyPathSet()
        {
            var path = base.GetAssemblyPath();
            bool isSet = false || !string.IsNullOrEmpty(path);
            return isSet;
        }

        /// <summary>
        /// Determines whether this instance is culture set.
        /// </summary>
        /// <returns><c>true</c> if this instance is culture set; otherwise, <c>false</c>.</returns>
        internal bool IsCultureSet()
        {
            return base.SetCulture();
        }

        /// <summary>
        /// Determines whether this instance is in memory loader set.
        /// </summary>
        /// <returns><c>true</c> if this instance is in memory loader set; otherwise, <c>false</c>.</returns>
        internal bool IsInMemoryLoaderSet()
        {
            return base.SetInMemoryLoader();
        }

        /// <summary>
        /// Determines whether this instance is registry set.
        /// </summary>
        /// <returns><c>true</c> if this instance is registry set; otherwise, <c>false</c>.</returns>
        internal bool IsRegistrySet()
        {
            return base.SetClassRegistry();
        }

    }

}