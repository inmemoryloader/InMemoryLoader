//
// ObjectHelper.cs
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

namespace InMemoryLoader.Helper
{
    /// <summary>
    ///     Object helper.
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        ///     Gets the field value.
        /// </summary>
        /// <returns>The field value.</returns>
        /// <param name="fieldName">Field name.</param>
        /// <param name="paramObject">Parameter object.</param>
        public static object GetFieldValue(string fieldName, object paramObject)
        {
            if (string.IsNullOrEmpty(fieldName) || paramObject == null) throw new ArgumentNullException();
            var value = paramObject.GetType().GetField(fieldName).GetValue(paramObject);
            return value;
        }

        /// <summary>
        ///     Gets the property value.
        /// </summary>
        /// <returns>The property value.</returns>
        /// <param name="propertyName">Property name.</param>
        /// <param name="paramObject">Parameter object.</param>
        public static object GetPropertyValue(string propertyName, object paramObject)
        {
            if (string.IsNullOrEmpty(propertyName) || paramObject == null) throw new ArgumentNullException();
            var value = paramObject.GetType().GetProperty(propertyName).GetValue(paramObject);
            return value;
        }
    }
}