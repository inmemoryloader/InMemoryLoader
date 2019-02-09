//
// EnumParserExtension.cs
//
// Author: Kay Stuckenschmidt <dev-guru@responsive-it.biz>
//
// Copyright (c) 2010 responsive IT
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
//

using System;

namespace InMemoryLoader
{

    /// <summary>
    /// Enum parser extension.
    /// </summary>
    public static class EnumParserExtension
    {

        /// <summary>
        /// Tos the enum.
        /// </summary>
        /// <returns>The enum.</returns>
        /// <param name="val">Value.</param>
        /// <typeparam name="TEnum">The 1st type parameter.</typeparam>
        public static TEnum ToEnum<TEnum>(this int val)
        {
            return (TEnum)System.Enum.ToObject(typeof(TEnum), val);
        }

        /// <summary>
        /// Tos the enum.
        /// </summary>
        /// <returns>The enum.</returns>
        /// <param name="val">Value.</param>
        /// <typeparam name="TEnum">The 1st type parameter.</typeparam>
        public static TEnum ToEnum<TEnum>(this long val)
        {
            return (TEnum)System.Enum.ToObject(typeof(TEnum), val);
        }

        /// <summary>
        /// Tos the enum.
        /// </summary>
        /// <returns>The enum.</returns>
        /// <param name="val">Value.</param>
        /// <typeparam name="TEnum">The 1st type parameter.</typeparam>
        public static TEnum ToEnum<TEnum>(this string val)
        {
            return (TEnum)System.Enum.Parse(typeof(TEnum), val);
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was tryed, <c>false</c> otherwise.</returns>
        /// <param name="theEnum">The enum.</param>
        /// <param name="valueToParse">Value to parse.</param>
        /// <param name="returnValue">Return value.</param>
        /// <typeparam name="TEnum">The 1st type parameter.</typeparam>
        public static bool TryParse<TEnum>(this Enum theEnum, int valueToParse, out TEnum returnValue)
        {
            returnValue = default(TEnum);
            int intEnumValue;
            if (Int32.TryParse(valueToParse.ToString(), out intEnumValue))
            {
                if (Enum.IsDefined(typeof(TEnum), intEnumValue))
                {
                    returnValue = (TEnum)(object)intEnumValue;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was tryed, <c>false</c> otherwise.</returns>
        /// <param name="theEnum">The enum.</param>
        /// <param name="valueToParse">Value to parse.</param>
        /// <param name="returnValue">Return value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool TryParse<T>(this Enum theEnum, long valueToParse, out T returnValue)
        {
            returnValue = default(T);
            int intEnumValue;
            if (Int32.TryParse(valueToParse.ToString(), out intEnumValue))
            {
                if (Enum.IsDefined(typeof(T), intEnumValue))
                {
                    returnValue = (T)(object)intEnumValue;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was tryed, <c>false</c> otherwise.</returns>
        /// <param name="theEnum">The enum.</param>
        /// <param name="valueToParse">Value to parse.</param>
        /// <param name="returnValue">Return value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
        {
            returnValue = default(T);
            int intEnumValue;
            if (Int32.TryParse(valueToParse, out intEnumValue))
            {
                if (Enum.IsDefined(typeof(T), intEnumValue))
                {
                    returnValue = (T)(object)intEnumValue;
                    return true;
                }
            }
            return false;
        }

    }

}
