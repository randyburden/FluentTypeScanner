/*  
FluentTypeScanner https://github.com/randyburden/FluentTypeScanner

Description:
------------

FluentTypeScanner is a .NET library used to scan for types using various scanning strategies expressed in a fluent-based declarative syntax.
    
FluentTypeScanner was originally developed as a tool to assist in creating extensible modular software by allowing software authors to scan
for types implementing their libraries interfaces, classes, attributes, etc. using a fluent-based declarative syntax.
    
MIT License:
------------

Copyright (c) 2013, Randy Burden ( http://randyburden.com ) All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
IN THE SOFTWARE.
*/

using System;

namespace FluentTypeScanner
{
    /// <summary>
    /// Convenience class for configuring a <see cref="TypeScannerConfiguration"/>. 
    /// </summary>
    public static class TypeScanner
    {
        /// <summary>
        /// Convenience method for configuring a <see cref="TypeScannerConfiguration"/>. 
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure( Action<TypeScannerConfiguration> configuration )
        {
            var typeScannerConfiguration = new TypeScannerConfiguration();

            configuration( typeScannerConfiguration );
        }
    }
}