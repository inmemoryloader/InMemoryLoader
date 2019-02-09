//
// HtmlEncodeExtension.cs
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
    /// Html encode extension.
    /// </summary>
    public static class HtmlEncodeExtension
    {

        /// <summary>
        /// Htmls the encode.
        /// </summary>
        /// <returns>The encode.</returns>
        /// <param name="paramString">Parameter string.</param>
        public static string HtmlEncode(this string paramString)
        {
            var source = paramString;

            var srcApos = Convert.ToChar("'");
            var srcQuote = Convert.ToString('"');
            var replApos = Convert.ToChar(srcQuote);

            var str1 = source.Replace("<", "&lt;");
            var str2 = source.Replace(">", "&gt;");
            var str3 = source.Replace("«", "&laquo;");
            var str4 = source.Replace("»", "&raquo;");
            var str5 = source.Replace("(", "&lang;");
            var str6 = source.Replace(")", "&rang;");
            var str7 = source.Replace("©", "&copy;");
            var str8 = source.Replace(srcApos, replApos);
            //var str9 = source.Replace(srcQuote, "&quot;");

            return str8;
        }

    }
}
